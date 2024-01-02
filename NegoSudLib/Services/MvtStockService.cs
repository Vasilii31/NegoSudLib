using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Services
{
    public class MvtStocksServices
    {
        private readonly NegoSudDBContext _context;
        private readonly DetailMouvementStockService _detailMouvementStockService;
        public MvtStocksServices(NegoSudDBContext context)
        {
            _context = context;
            _detailMouvementStockService = new DetailMouvementStockService(context);
        }

        //public ICollection<MvtStockDTO>? getMvtByEmploye(int employeId)
        //{
        //    ICollection<MvtStockDTO> mvts = _context.MouvementsStocks
        //        .Where(mvt => mvt.EmployeId == employeId && (!(mvt is Vente) && !(mvt is Commande)))
        //        .Select(vente => new MvtStockDTO
        //        {
        //            Id = vente.EmployeId,
        //            NomEmploye = vente.Employe.NomUtilisateur,
        //            PrenomEmploye = vente.Employe.PrenomUtilisateur,
        //            Commentaire = vente.Commentaire,
        //            DateMouvement = vente.DateMouvement
        //        })
        //        .ToList();
        //    if (mvts.Count == 0) { return null; }
        //    foreach (var mvt in mvts)
        //    {
        //        mvt.DetailMouvementStocks = _detailMouvementStockService.getDetailByMouvementId(mvt.Id);
        //    }
        //    return mvts;
        //}

        //public VenteDTO venteToVenteDTO(Vente v)
        //{
        //    VenteDTO venteDTO = new VenteDTO{
        //        Id = v.Id,
        //        NumFacture = v.NumFacture,
        //        NomClient = v.Client.NomUtilisateur,
        //        PrenomClient = v.Client.PrenomUtilisateur,
        //        NomEmploye = v.Employe.NomUtilisateur,
        //        PrenomEmploye = v.Employe.PrenomUtilisateur,
        //        Commentaire = v.Commentaire,
        //        DateMouvement = v.DateMouvement
        //        };

        //    venteDTO.DetailMouvementStocks = _detailMouvementStockService.getDetailByMouvementId(v.Id);

        //    return venteDTO;
        //}
    }
}
