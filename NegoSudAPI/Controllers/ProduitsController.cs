using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
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
        [HttpGet("/recherche")]
        public async Task<ActionResult<IEnumerable<ProduitLightDTO>>> Search([FromQuery] int cat, [FromQuery] int dom, [FromQuery] string? nom, [FromQuery] bool? enVente)
        {
            var produit = await _produitService.Search(cat, dom, nom, enVente);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(produit);
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
        [Authorize(Roles = "Gérant")]
        [HttpPost]
        public async Task<ActionResult<ProduitFullDTO?>> AddProduit([FromBody] ProduitWriteDTO produit)
        {
            if (produit == null)
            {
                return BadRequest("Impossible d'ajouter un produit sans données");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produitCreated = await _produitService.Post(produit);
            if (produitCreated != null) return CreatedAtAction(nameof(GetbyId), new { id = produitCreated.Id }, produitCreated);

            return StatusCode(500, "Une erreur interne du serveur s'est produite.");


        }

        // PUT api/<ValuesController>/5
        //[Authorize]
        [Authorize(Roles = "Gérant")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProduitFullDTO?>> updateProduit(int id, [FromBody] ProduitWriteDTO produitNew)
        {
            // Renvoyer un code 404 si le produit n'est pas trouvé
            if (!(await _produitService.Exists(id))) return NotFound();

            if (produitNew == null) return BadRequest("Impossible de modifier un produit sans données");

            if (!ModelState.IsValid) return BadRequest(ModelState);


            var produitUpdated = await _produitService.Put(produitNew);
            if (produitUpdated != null) return Ok(produitNew);

            return StatusCode(500, "Une erreur interne du serveur s'est produite.");
        }

        // DELETE api/<ValuesController>/5
        [Authorize(Roles = "Gérant")]
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
