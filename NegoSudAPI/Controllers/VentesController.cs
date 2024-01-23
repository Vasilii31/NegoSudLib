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
    public class VentesController : ControllerBase
    {

        private readonly IVentesService _ventesService;

         public VentesController(IVentesService ventesService)
        {
            _ventesService = ventesService;
        }


        // GET: api/Commandes    => Tous les Commandes 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentesDTO>>> GetAll()
        {

            var ventes = await _ventesService.GetAll();
            if (ventes.Any())
            {
                return Ok(ventes);
            }
            return NotFound();
                  
        }

        // GET api/Commandes/5
        [HttpGet("{idNum}")]
        public async Task<ActionResult<VentesDTO?>> Getby(string idNum)
        {
            if (int.TryParse(idNum ,out int id))
            {
                // Si id est un entier on chercher par l'id
                var vente = await _ventesService.GetById(id);
                if (vente == null)
                {
                    return NotFound();
                }
                return Ok(vente);
            }
            else
            {
                // Si id est une chaine on chercher par le numero 
                var vente = await _ventesService.GetByNum(idNum);
                if (vente == null)
                {
                    return NotFound();
                }
                return Ok(vente);
            }


            
        }

        // POST api/<ValuesController>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<VentesDTO?>> Post([FromBody] Vente vente)
        {
            if (vente != null)
            {
                var produitCreated = await _ventesService.Post(vente);
                if (produitCreated != null) return Ok(produitCreated);

                return  StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
                // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
                return BadRequest("L'objet produit est null.");
        }

        // PUT api/<ValuesController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Commande?>> Put(int id, [FromBody] Vente vente)
        {
            // Renvoyer un code 404 si le produit n'est pas trouvé
            if (!(await _ventesService.Exists(id))) return NotFound();

            var produitUpdated = await _ventesService.Put(vente);
            if ( produitUpdated != null) return Ok(vente);
           
            return StatusCode(500, "Une erreur interne du serveur s'est produite.");
        }

        // DELETE api/<ValuesController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            if (!await _ventesService.Exists(id))
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }

            try
            {
                await _ventesService.Delete(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
