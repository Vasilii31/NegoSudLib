using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudWeb.Services;
using Newtonsoft.Json;

namespace NegoSudWeb.Controllers
{
    public class PanierController : Controller
    {

        private readonly ILogger<HomeController> _logger; private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public PanierController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
                              SignInManager<User> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: PanierController
        public async Task<ActionResult> Index()
        {
            var panierJson = Request.Cookies["Panier"];
            var panier = new VentesWriteDTO();
            if (panierJson != null)
            {
                panier = JsonConvert.DeserializeObject<VentesWriteDTO>(panierJson);
            }
            panier.SetTotaux();
            return View(panier);
        }

        // GET: PanierController
        public async Task<ActionResult> ValiderPanier()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return RedirectToAction("Login", "Clients", new { returnUrl = "/Panier/ValiderPanier" });
            }
            return View();
        }


        public async Task<ActionResult> ValiderCommande(string password)
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);


            var panierJson = Request.Cookies["Panier"];
            var panier = new VentesWriteDTO();
            if (panierJson != null)
            {
                panier = JsonConvert.DeserializeObject<VentesWriteDTO>(panierJson);
            }
            else
            { return Json(new { success = false }); };

            panier.SetTotaux();
            var infoClientJson = _session.GetString("InfoClient");
            var client = JsonConvert.DeserializeObject<ClientDTO>(infoClientJson);
            panier.ClientId = client.Id;


            /*var venteToAdd = panier;
            foreach (var lgn in venteToAdd.DetailMouvementStocks)
            {
                lgn.Produit = null;
            }*/

            panier.EmployeId = 1;
            var connectedToAPI = await httpClientService.Login(user.UserName, password); ;
            if (!connectedToAPI) { return Json(new { success = false }); };

            var venteAdded = await httpClientService.AddVente(panier, user);
            if (venteAdded != null)
            { return Json(new { success = true }); }
            else
            { return Json(new { success = false }); };
        }





    }
}
