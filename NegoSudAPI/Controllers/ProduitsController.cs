using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {

        private readonly IProduitsServices _produitService;

         public ProduitsController(IProduitsServices produitService)
        {
            _produitService = produitService;
        }


        // GET: api/produits    => Tous les produits 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduitLightDTO>>> GetAll([FromQuery] bool? EstEnVente)
        {

            var produits = await _produitService.GetAll(EstEnVente);
            if (produits.Any())
            {
                return Ok(produits);
            }
            return NotFound();
                  
        }

/*        // GET: api/produits    => Tous les produits en vente
        [HttpGet("EnVente")]
        public async Task<ActionResult<IEnumerable<ProduitLightDTO>>> GetAllEnvente()
        {
       
            var produits = await _produitService.GetAll(true);
            if (produits.Any())
            {
                return Ok(produits);
            }
            return NotFound();
 
        }*/

 /*       // GET: api/produits/NonEnVente Tous les produits (non en vente) 
        [HttpGet("NonEnVente")]
        public async Task<ActionResult<IEnumerable<ProduitLightDTO>>> GetAllNonEnVente()
        {
            var produits = await _produitService.GetAll(false);
            if (produits.Any())
            {
                return Ok(produits);
            }
            return NotFound();
        }*/


        [HttpGet("Categorie/{catId}")]
        public async Task<ActionResult<IEnumerable<ProduitLightDTO>>> GetByCat(int catId)
        {
            var produits = await _produitService.GetByCat(catId);
            

            if (produits.Any())
            {
                return Ok(produits);
            }
            return NotFound();
        }

        [HttpGet("Domaine/{domId}")]
        public async Task<ActionResult<IEnumerable<ProduitLightDTO>>> GetByDom(int domId)
        {
            if (domId <= 0)
            {
                throw (new Exception("Domaine invalide"));
            }

            var produits = await _produitService.GetByDom(domId);

            if (produits.Any())
            {
                return Ok(produits);
            }
            return NotFound();
        }



        // GET api/produits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProduitFullDTO?>> GetbyId(int id)
        {
            var produit = await _produitService.GetById(id);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(produit);
        }

        // POST api/<ValuesController>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<ProduitFullDTO?>> AddProduit([FromBody] ProduitWriteDTO produit)
        {
            if (produit != null)
            {
                var produitCreated = await _produitService.Post(produit);
                if (produitCreated != null) return Ok(produitCreated);

                return  StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
                // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
                return BadRequest("L'objet produit est null.");
        }

        // PUT api/<ValuesController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProduitFullDTO?>> updateProduit(int id, [FromBody] ProduitWriteDTO produitNew)
        {
            // Renvoyer un code 404 si le produit n'est pas trouvé
            if (!(await _produitService.Exists(id))) return NotFound();

            var produitUpdated = await _produitService.Put(produitNew);
            if ( produitUpdated != null) return Ok(produitNew);
           
            return StatusCode(500, "Une erreur interne du serveur s'est produite.");
        }

        // DELETE api/<ValuesController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            if (!await _produitService.Exists(id))
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }

            try
            {
                await _produitService.Delete(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
