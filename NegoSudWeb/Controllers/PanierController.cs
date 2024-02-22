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
            if (_session == null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    ClientDTO clientConnecté = await httpClientService.GetClientByUserName(user.UserName);
                    var clientJson = JsonConvert.SerializeObject(clientConnecté);
                    _session.SetString("InfoClient", clientJson);
                }
            }

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
        public async Task<ActionResult> Valider()
        {
            if (_session == null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    ClientDTO clientConnecté = await httpClientService.GetClientByUserName(user.UserName);
                    var clientJson = JsonConvert.SerializeObject(clientConnecté);
                    _session.SetString("InfoClient", clientJson);
                }
            }


            return View();
        }





    }
}
