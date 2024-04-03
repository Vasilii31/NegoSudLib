using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using NegoSudLib.Services;

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventairesController : ControllerBase
    {
        private readonly IInventaireService _inventaireService;

		public InventairesController(IInventaireService inventaireService)
		{
			_inventaireService = inventaireService;
		}



		// GET: api/Inventaires
		[HttpGet]
        public async Task<ActionResult<IEnumerable<Inventaire>>> GetInventaires([FromQuery] bool? isValidated)
        {
            var inventaires = await _inventaireService.GetAll(isValidated);
            if(inventaires.Any())
            {
                return Ok(inventaires);
            }
            return NotFound();
        }

        // GET: api/Inventaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventaire>> GetInventaire(int id)
        {
            var inventaire = await _inventaireService.GetById(id);

            if (inventaire == null)
            {
                return NotFound();
            }
            return Ok(inventaire);
        }

        // PUT: api/Inventaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Inventaire?>> PutInventaire(int id, Inventaire inventaire)
        {
			// Renvoyer un code 404 si le produit n'est pas trouvé
			if (!(await _inventaireService.Exists(id))) return NotFound();

			if (inventaire == null) return BadRequest("Impossible de modifier un produit sans données");

			if (!ModelState.IsValid) return BadRequest(ModelState);


			var inventaireUpdated = await _inventaireService.Put(id, inventaire);
			if (inventaireUpdated != null) return Ok(inventaireUpdated);

			return StatusCode(500, "Une erreur interne du serveur s'est produite.");
		}

        // POST: api/Inventaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventaire>> PostInventaire(Inventaire inventaire)
        {
            if(inventaire == null)
            {
				return BadRequest("Impossible d'ajouter un inventaire sans données.");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

            var inventaireCreated = await _inventaireService.Post(inventaire);

            if (inventaireCreated != null)
			    return CreatedAtAction("GetInventaire", new { id = inventaire.Id }, inventaire);
            return StatusCode(500, "Une erreur interne du serveur s'est produite.");
		}

        // DELETE: api/Inventaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventaire(int id)
        {
			if (!await _inventaireService.Exists(id))
			{
				return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
			}

			try
			{
				await _inventaireService.Delete(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}

        }

    }
}
