using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Interfaces;
using NegoSudLib.Services;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutreMouvementController : ControllerBase
    {

        private readonly IAutreMvtService _autreMvtService;

         public AutreMouvementController(IAutreMvtService autreMvtService)
        {
            _autreMvtService = autreMvtService;
        }


        // GET: api/Commandes    => Tous les Commandes 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutreMvtDTO>>> GetAll()
        {

            var Commandes = await _autreMvtService.GetAll();
            if (Commandes.Any())
            {
                return Ok(Commandes);
            }
            return NotFound();
                  
        }

        // GET api/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutreMvtDTO?>> GetbyId(int id)
        {
            
                var commande = await _autreMvtService.GetById(id);
                if (commande == null)
                {
                    return NotFound();
                }
            return Ok(commande);
            
        }
                // GET api/type/5
        [HttpGet("type/{typeId}")]
        public async Task<ActionResult<IEnumerable<AutreMvtDTO?>>> GetbyType(int typeId)
        {
            
                var autreMvts = await _autreMvtService.GetByType(typeId);
            if (autreMvts.Any())
            {
                return Ok(autreMvts);
            }
            return NotFound();

        }

        // POST api/<ValuesController>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<AutreMvtDTO?>> Post([FromBody] AutreMouvement autreMvt)
        {
            if (autreMvt != null)
            {
                var produitCreated = await _autreMvtService.Post(autreMvt);
                if (produitCreated != null) return Ok(produitCreated);

                return  StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
                // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
                return BadRequest("L'objet produit est null.");
        }

        // PUT api/<ValuesController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Commande?>> Put(int id, [FromBody] AutreMouvement autreMvt)
        {
            // Renvoyer un code 404 si le produit n'est pas trouvé
            if (!(await _autreMvtService.Exists(id))) return NotFound();

            var produitUpdated = await _autreMvtService.Put(autreMvt);
            if ( produitUpdated != null) return Ok(autreMvt);
           
            return StatusCode(500, "Une erreur interne du serveur s'est produite.");
        }

        // DELETE api/<ValuesController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            if (!await _autreMvtService.Exists(id))
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }

            try
            {
                await _autreMvtService.Delete(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
