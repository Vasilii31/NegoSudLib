using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudLib.Interfaces;


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
        [Authorize]
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
        public async Task<ActionResult<AutreMvtDTO?>> Post([FromBody] AutreMvtWriteDTO autreMvt)
        {
            if (autreMvt == null) return BadRequest("Impossible d'ajouter un mouvement de stock sans données");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mvtCreated = await _autreMvtService.Post(autreMvt);
            if (mvtCreated != null) return CreatedAtAction(nameof(GetbyId), new { id = mvtCreated.Id }, mvtCreated);


            return StatusCode(500, "Une erreur interne du serveur s'est produite.");
        }

        // PUT api/<ValuesController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Commande?>> Put(int id, [FromBody] AutreMvtWriteDTO autreMvt)
        {
            // Renvoyer un code 404 si le produit n'est pas trouvé
            if (!(await _autreMvtService.Exists(id))) return NotFound();

            var produitUpdated = await _autreMvtService.Put(id, autreMvt);
            if (produitUpdated != null) return Ok(autreMvt);

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
