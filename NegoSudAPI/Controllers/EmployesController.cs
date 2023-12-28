using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Services;

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {

        private readonly EmployesService _employesService;

        public EmployesController(EmployesService employesService)
        {
            _employesService = employesService;
        }

        [HttpGet]
        public IActionResult GetEmployes()
        {
            var employes = _employesService.GetEmployes();
            if (employes.Count == 0)
            {
                return NotFound();
            }
            return Ok(employes);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetbyId(int id)
        {
            var employe = _employesService.getEmployeById(id);
            if (employe == null)
            {
                return NotFound();
            }

            return Ok(employe);
        }


        [HttpGet("mail/{email}")]
        public IActionResult GetbyEmail(string email)
        {
            var employe = _employesService.getEmployeByEmail(email);
            if (employe == null)
            {
                return NotFound();
            }

            return Ok(employe);
        }

        [HttpPost]
        public IActionResult AddEmploye([FromBody]EmployeDTO employe)
        {
            if (employe == null)
            {
                // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
                return BadRequest("L'objet produit est null.");
            }
            employe.Id = _employesService.addEmploye(employe);
            if (employe.Id != 0)
            {
                // Retourne un statut 201 Created avec l'objet produit dans le corps de la réponse
                // et un lien vers l'action "Get" pour récupérer la nouvelle ressource.
                return CreatedAtAction(nameof(GetbyId), new { id = employe.Id }, employe);
            }

                return StatusCode(500, "Une erreur est survenue à la création de l'employé");
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteEmploye(int id) {

            var employe = _employesService.getEmployeById(id);

            if (employe == null)
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }


            if (_employesService.deleteEmploye(id))
            {
                return NoContent();
            }
            return StatusCode(500);
        }


    }
}
