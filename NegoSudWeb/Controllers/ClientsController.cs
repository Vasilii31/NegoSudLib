using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudWeb.Models;
using NegoSudWeb.Services;
using Newtonsoft.Json;

namespace NegoSudWeb.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public ClientsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
                              SignInManager<User> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) { RedirectToAction(nameof(Register)); }
            ClientDTO clientConnecté = await httpClientService.GetClientByUserName(user.UserName);
            return View(clientConnecté);
        }


        // GET: Clients/register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName,NomUtilisateur,PrenomUtilisateur,AdresseUtilisateur,MailUtilisateur,NumTelUtilisateur,MotDePasse")] ClientDTO client)
        {

            if (ModelState.IsValid)
            {
                var clientAdded = await httpClientService.AddClient(client);
                var result = _signInManager.PasswordSignInAsync(client.UserName, client.MotDePasse, true, lockoutOnFailure: false).Result;
                if (result.Succeeded)
                {
                    var logApi = await httpClientService.Login(client.UserName, client.MotDePasse);
                    if (logApi)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            return View(client);
        }





        // GET: Clients/Login
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        // POST: Clients/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details,see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password,RememberMe,ReturnUrl")] LoginViewModel client)
        {
            if (!ModelState.IsValid) return View();

            var resultSign = _signInManager.PasswordSignInAsync(client.Username, client.Password, client.RememberMe, lockoutOnFailure: false).Result;
            var result = await httpClientService.Login(client.Username, client.Password);


            if (result && resultSign.Succeeded)
            {
                ClientDTO clientConnecté = await httpClientService.GetClientByUserName(client.Username);
                HttpContext.Session.SetString("InfoClient", JsonConvert.SerializeObject(clientConnecté));
                return Redirect(client.ReturnUrl ?? "~/");
            }
            return View(client);
        }





        // GET: Clients/LogOut
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete("Panier");
            return RedirectToAction("Index", "Home");
        }

        // GET: Clients/Edit
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ClientDTO clientConnecté = await httpClientService.GetClientByUserName(user.UserName);
            if (user != null) return View(clientConnecté);
            return RedirectToAction("Index", "Home");
        }
        // POST: Clients/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("UserName,NomUtilisateur,PrenomUtilisateur,AdresseUtilisateur,MailUtilisateur,NumTelUtilisateur,MotDePasse")] ClientDTO client)
        {

            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(client.UserName, client.MotDePasse, true, lockoutOnFailure: false).Result;
                if (result.Succeeded) return RedirectToAction(nameof(Index));
            }

            return View(client);
        }





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
