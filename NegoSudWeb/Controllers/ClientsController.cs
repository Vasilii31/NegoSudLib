using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DTO.Read;
using NegoSudWeb.Services;

namespace NegoSudWeb.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session;

        public ClientsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }


        // GET: Clients
        public async Task<IActionResult> Index(ClientDTO client)
        {
            return View(client);
        }

        // GET: Clients/Details/5
        /* public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var client = await _context.Clients
                 .Include(c => c.User)
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (client == null)
             {
                 return NotFound();
             }

             return View(client);
         }*/

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,NomUtilisateur,PrenomUtilisateur,AdresseUtilisateur,MailUtilisateur,NumTelUtilisateur,MotDePasse")] ClientDTO client)
        {

            if (ModelState.IsValid)
            {
                var clientAdded = await httpClientService.AddClient(client);
                return RedirectToAction(nameof(Index), client);
            }
            return View(client);
        }
        // POST: Clients/Connect
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Connect([Bind("UserName,MotDePasse")] ClientDTO client)
        {

            if (ModelState.IsValid)
            {
                var clientAdded = await httpClientService.AddClient(client);
                return RedirectToAction(nameof(Index), client);
            }
            return View(client);
        }

        /*       // GET: Clients/Edit/5
               public async Task<IActionResult> Edit(int? id)
               {
                   if (id == null)
                   {
                       return NotFound();
                   }

                   var client = await _context.Clients.FindAsync(id);
                   if (client == null)
                   {
                       return NotFound();
                   }
                   ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", client.UserId);
                   return View(client);
               }*/

        /* // POST: Clients/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("NumClient,Id,UserId,NomUtilisateur,PrenomUtilisateur,AdresseUtilisateur,NumTelUtilisateur")] Client client)
         {
             if (id != client.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(client);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!ClientExists(client.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", client.UserId);
             return View(client);
         }*/

        /*  // GET: Clients/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var client = await _context.Clients
                  .Include(c => c.User)
                  .FirstOrDefaultAsync(m => m.Id == id);
              if (client == null)
              {
                  return NotFound();
              }

              return View(client);
          }

          // POST: Clients/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(int id)
          {
              var client = await _context.Clients.FindAsync(id);
              if (client != null)
              {
                  _context.Clients.Remove(client);
              }

              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }
  */

    }
}
