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
    public class CommandesController : ControllerBase
    {

        private readonly ICommandesService _commandeservice;

         public CommandesController(ICommandesService commandeservice)
        {
            _commandeservice = commandeservice;
        }


        // GET: api/Commandes    => Tous les Commandes 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandeDTO>>> GetAll()
        {

            var Commandes = await _commandeservice.GetAll();
            if (Commandes.Any())
            {
                return Ok(Commandes);
            }
            return NotFound();
                  
        }

        // GET api/Commandes/5
        [HttpGet("{idNum}")]
        public async Task<ActionResult<CommandeDTO?>> Getby(string idNum)
        {
            if (int.TryParse(idNum ,out int id))
            {
                // Si id est un entier on chercher par l'id
                var commande = await _commandeservice.GetById(id);
                if (commande == null)
                {
                    return NotFound();
                }
                return Ok(commande);
            }
            else
            {
                // Si id est une chaine on chercher par le numero 
                var commande = await _commandeservice.GetByNum(idNum);
                if (commande == null)
                {
                    return NotFound();
                }
                return Ok(commande);
            }      
        }
         // GET api/Commandes/5
        [HttpGet("statut/{statut}")]
        public async Task<ActionResult<IEnumerable<CommandeDTO?>>> GetByStatut(Statuts statut)
        {
            var Commandes = await _commandeservice.GetByStatut(statut);
            if (Commandes.Any())
            {
                return Ok(Commandes);
            }
            return NotFound();

        }

        // POST api/<ValuesController>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<CommandeDTO?>> Post([FromBody] Commande commande)
        {
            if (commande != null)
            {
                var produitCreated = await _commandeservice.Post(commande);
                if (produitCreated != null) return Ok(produitCreated);

                return  StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
                // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
                return BadRequest("L'objet produit est null.");
        }

        // PUT api/<ValuesController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Commande?>> Put(int id, [FromBody] Commande commande)
        {
            // Renvoyer un code 404 si le produit n'est pas trouvé
            if (!(await _commandeservice.Exists(id))) return NotFound();

            var produitUpdated = await _commandeservice.Put(commande);
            if ( produitUpdated != null) return Ok(commande);
           
            return StatusCode(500, "Une erreur interne du serveur s'est produite.");
        }

        // DELETE api/<ValuesController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            if (!await _commandeservice.Exists(id))
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }

            try
            {
                await _commandeservice.Delete(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
