using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudWeb.Models;
using NegoSudWeb.Services;
using Newtonsoft.Json;

namespace NegoSudWeb.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ProduitsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
                              SignInManager<User> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: Produits/Index
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                ClientDTO clientConnecté = await httpClientService.GetClientByUserName(user.UserName);
                var clientJson = JsonConvert.SerializeObject(clientConnecté);
                _session.SetString("InfoClient", clientJson);
            }
            var produits = await httpClientService.GetProduitsAll();
            return View(produits);
        }

        // GET: Produits
        public async Task<IActionResult> Categorie(int id)
        {
            var produits = new List<ProduitsViewModel>();

            if (id <= 0) return NotFound();

            produits = await httpClientService.SearchProduits(id, 0, 0, null, null);

            return View(produits);

        }
        // GET: Produits
        public async Task<IActionResult> Recherche(string nom)
        {
            var produits = new List<ProduitsViewModel>();

            produits = await httpClientService.SearchProduits(0, 0, 0, nom, null);

            return PartialView("_Produit", produits);

        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.Categorie)
                .Include(p => p.Domaine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);*/
            throw new NotImplementedException();
        }




        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int qteUnite, int qteCarton)
        {
            var product = await httpClientService.GetProductById(productId);
            if (product == null)
            {
                Json(new { success = false });
            }

            var dtMvtUnite = new DetailMouvementStockDTO();
            var dtMvtCarton = new DetailMouvementStockDTO();
            if (qteUnite != 0)
            {
                dtMvtUnite.ProduitId = product.Id;
                dtMvtUnite.Produit = product;
                dtMvtUnite.AuCarton = false;
                dtMvtUnite.QteProduit = qteUnite;
                dtMvtUnite.PrixApresRistourne = -1;

            }
            if (qteCarton != 0)
            {
                dtMvtCarton.ProduitId = product.Id;
                dtMvtCarton.Produit = product;
                dtMvtCarton.AuCarton = true;
                dtMvtCarton.QteProduit = qteCarton;
                dtMvtCarton.PrixApresRistourne = -1;

            };

            //var shoppingCart = HttpContext.Session.Get<VentesWriteDTO>("Panier") ?? new VentesWriteDTO();
            var panierJson = Request.Cookies["Panier"];


            var panier = new VentesWriteDTO();
            if (panierJson != null)
            {
                panier = JsonConvert.DeserializeObject<VentesWriteDTO>(panierJson);
            }
            if (dtMvtUnite.ProduitId != 0)
            {
                var mvt = panier.DetailMouvementStocks.FirstOrDefault(item => item.ProduitId == dtMvtUnite.ProduitId && item.AuCarton == dtMvtUnite.AuCarton);
                if (mvt == null)
                {
                    panier.DetailMouvementStocks.Add(dtMvtUnite);
                }
                else
                {
                    mvt.QteProduit += dtMvtUnite.QteProduit;
                }
            }
            if (dtMvtCarton.ProduitId != 0)
            {
                var mvt = panier.DetailMouvementStocks.FirstOrDefault(item => item.ProduitId == dtMvtCarton.ProduitId && item.AuCarton == dtMvtCarton.AuCarton);
                if (mvt == null)
                {
                    panier.DetailMouvementStocks.Add(dtMvtCarton);
                }
                else
                {
                    mvt.QteProduit += dtMvtCarton.QteProduit;
                }
            }
            panierJson = JsonConvert.SerializeObject(panier);

            Response.Cookies.Append("Panier", panierJson);
            //_session.SetString("Panier", panierJson);
            /*var test = _session.GetString("Panier");
			Console.Write(test);*/
            return Json(new { success = true });
        }



        [HttpPost]
        public async Task<IActionResult> UpdateCart(string panierJson)
        {
            //_session.SetString("Panier", panierJson);
            Response.Cookies.Append("Panier", panierJson);
            return Json(new { success = true });
        }


    }
}
