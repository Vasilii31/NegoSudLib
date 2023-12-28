using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Services
{
    public class DetailMouvementStockService
    {
        private readonly NegoSudDBContext _context;
        private readonly ProduitService _produitService;

        public DetailMouvementStockService(NegoSudDBContext context)
        {
            _context = context;
            _produitService = new ProduitService(context);
        }

        public ICollection<DetailMouvementStockDTO> getDetailByMouvementId(int mouvementId)
        {
            MouvementStock Mvt = _context.MouvementsStocks.Find(mouvementId);
            DateTime dateMvt = Mvt.DateMouvement;

            ICollection<DetailMouvementStockDTO> details = _context.DetailsMouvementStock
                .Where(detail => detail.MouvementStockId == mouvementId)
                .Select(detail => new DetailMouvementStockDTO
                {
                    QteProduit = detail.QteProduit,
                    PrixApresRistourne = detail.PrixApresRistourne,
                    AuCarton = detail.AuCarton,
                    produitId = detail.ProduitId
                })
                .ToList();

            

             foreach (var detail in details) {
                detail.Produit = _produitService.GetProduitByIdDate(detail.produitId,dateMvt);
             }
            return details;
        }
    }
}
