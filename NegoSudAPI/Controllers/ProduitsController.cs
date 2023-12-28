using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly ProduitService _produitService;

         public ProduitsController(ProduitService produitService)
        {
            _produitService = produitService;
        }


        // GET: api/produits
        [HttpGet]
        public IActionResult GetProduits()
        {
            var produits = _produitService.getProduits();
            if (produits.Count == 0)
            {
                return NotFound();
            }
            return Ok(produits);
        }

        // GET api/produits/5
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var produit = _produitService.getProduitById(id);
            if (produit == null)
            {
                return NotFound();
            }
            
            return Ok(produit);
        }

        // POST api/<ValuesController>
        //[Authorize]
        [HttpPost]
        public IActionResult AddProduit([FromBody] ProduitWriteDTO produit)
        {
            if (produit == null)
            {
                // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
                return BadRequest("L'objet produit est null.");
            }
            produit.Id = _produitService.AddProduit(produit);
            if (produit.Id != 0)
            {
            // Retourne un statut 201 Created avec l'objet produit dans le corps de la réponse
            // et un lien vers l'action "Get" pour récupérer la nouvelle ressource.
            return CreatedAtAction(nameof(GetbyId), new { id = produit.Id }, produit);
            }else
            {
                return BadRequest();
            }
        }

        // PUT api/<ValuesController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult updateProduit(int id,[FromBody] ProduitWriteDTO produitNew)
        {
            var produitOld = _produitService.getProduitById(id);

            if (produitOld == null)
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }

            if (_produitService.UpdateProduit(produitNew))
            {
                return Ok(produitNew);           
            }

            return BadRequest();

        }

        // DELETE api/<ValuesController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var produit = _produitService.getProduitById(id);

            if (produit == null)
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }


            if (_produitService.DeleteProduit(id))
            {
                return NoContent();
            }
            return StatusCode(500);
        }
    }
}
