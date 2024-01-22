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
    public class EmployesController : ControllerBase
    {
        private readonly IEmployesService _employesService;

        public EmployesController(IEmployesService employesService)
        {
            _employesService = employesService;
        }

        // GET: api/Employes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetAll()
        {
            var employe = await _employesService.GetAll();
            if (employe.Any())
            {
                return Ok(employe);
            }
            return NotFound();
        }

        // GET: api/Employes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetById(int id)
        {

            var employes = await _employesService.GetById(id);
            if (employes != null)
            {
                return Ok(employes);
            }
            return NotFound();
        }
        
        [HttpGet("mail/{mail}")]
        public async Task<ActionResult<Employe>> GetByMail(string mail)
        {

            var employes = await _employesService.GetByMail(mail);
            if (employes != null)
            {
                return Ok(employes);
            }
            return NotFound();
        }

        // PUT: api/Employes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(int id, Employe employe)
        {
            if (!await _employesService.Exists(id))
            {
                return NotFound();
            }
            if (employe != null)
            {
                var produitCreated = await _employesService.Put(employe);
                if (produitCreated != null) return Ok(produitCreated);

                return StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
            // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
            return BadRequest("L'objet produit est null.");
        }

        // POST: api/Employes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employe>> PostEmploye(Employe employe)
        {
            if (employe != null)
            {
                var produitCreated = await _employesService.Post(employe);
                if (produitCreated != null) return Ok(produitCreated);

                return StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
            // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
            return BadRequest("L'objet employe est null.");
        }

        // DELETE: api/Employes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploye(int id)
        {
            if (!await _employesService.Exists(id))
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }

            await _employesService.Delete(id);
            return NoContent();
        }

        
    }
}
