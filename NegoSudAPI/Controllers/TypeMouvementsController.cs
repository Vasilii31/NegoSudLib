using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Write;
using NegoSudLib.NegosudDbContext;

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TypeMouvementsController : ControllerBase
    {
        private readonly NegoSudDBContext _context;

        public TypeMouvementsController(NegoSudDBContext context)
        {
            _context = context;
        }

        // GET: api/TypeMouvements
        [Authorize(Roles = "Gérant,Employe")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeMouvement>>> GetTypesMouvement()
        {
            return await _context.TypesMouvement.ToListAsync();
        }

        // GET: api/TypeMouvements/5
        [Authorize(Roles = "Gérant,Employe")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeMouvement>> GetTypeMouvement(int id)
        {
            var typeMouvement = await _context.TypesMouvement.FindAsync(id);

            if (typeMouvement == null)
            {
                return NotFound();
            }

            return typeMouvement;
        }

        // PUT: api/TypeMouvements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Gérant,Employe")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeMouvement(int id, TypeMouvement typeMouvement)
        {
            if (id != typeMouvement.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeMouvement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeMouvementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TypeMouvements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Gérant")]
        [HttpPost]
        public async Task<ActionResult<TypeMouvement>> PostTypeMouvement(TypeMouvement typeMouvement)
        {
            
            _context.TypesMouvement.Add(typeMouvement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeMouvement", new { id = typeMouvement.Id }, typeMouvement);
        }

        // DELETE: api/TypeMouvements/5
        [Authorize(Roles = "Gérant")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeMouvement(int id)
        {
            var typeMouvement = await _context.TypesMouvement.FindAsync(id);
            if (typeMouvement == null)
            {
                return NotFound();
            }

            _context.TypesMouvement.Remove(typeMouvement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeMouvementExists(int id)
        {
            return _context.TypesMouvement.Any(e => e.Id == id);
        }
    }
}
