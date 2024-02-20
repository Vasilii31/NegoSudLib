﻿using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudWeb.Services;
using Newtonsoft.Json;

namespace NegoSudWeb.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session;

        public ProduitsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }


        // GET: Produits
        public async Task<IActionResult> Index()
        {

            var produits = await httpClientService.GetProduitsAll();
            return View(produits);

            //return View(await negoSudDBContext.ToListAsync());
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

            }
            if (qteCarton != 0)
            {
                dtMvtCarton.ProduitId = product.Id;
                dtMvtCarton.Produit = product;
                dtMvtCarton.AuCarton = true;
                dtMvtCarton.QteProduit = qteCarton;
            };

            //var shoppingCart = HttpContext.Session.Get<VentesWriteDTO>("Panier") ?? new VentesWriteDTO();
            var panierJson = _session.GetString("Panier");
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
            _session.SetString("Panier", panierJson);
            var test = _session.GetString("Panier");
            Console.Write(test);
            return Json(new { success = true });
        }






    }
}
