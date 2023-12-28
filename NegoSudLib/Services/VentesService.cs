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
    public class VentesService
    {
        private readonly NegoSudDBContext _context;
        private readonly DetailMouvementStockService _detailMouvementStockService;
        public VentesService(NegoSudDBContext context)
        {
            _context = context;
            _detailMouvementStockService = new DetailMouvementStockService(context);
        }

        public ICollection<VenteDTO>? getVentesByEmploye(int employeId)
        {
            ICollection<VenteDTO> ventes = _context.Ventes
                .Where(vente => vente.EmployeId == employeId)
                .Select(vente => new VenteDTO
                {
                    Id = vente.EmployeId,
                    NumFacture = vente.NumFacture,
                    NomClient = vente.Client.NomUtilisateur,
                    PrenomClient = vente.Client.PrenomUtilisateur,
                    NomEmploye = vente.Employe.NomUtilisateur,
                    PrenomEmploye = vente.Employe.PrenomUtilisateur,
                    Commentaire = vente.Commentaire,
                    DateMouvement = vente.DateMouvement
                })
                .ToList();
            if (ventes.Count == 0) { return null; }
            foreach (var vente in ventes)
            {
                vente.DetailMouvementStocks = _detailMouvementStockService.getDetailByMouvementId(vente.Id);
            }
            return ventes;
        }

        public VenteDTO venteToVenteDTO(Vente v)
        {
            VenteDTO venteDTO = new VenteDTO{
                Id = v.Id,
                NumFacture = v.NumFacture,
                NomClient = v.Client.NomUtilisateur,
                PrenomClient = v.Client.PrenomUtilisateur,
                NomEmploye = v.Employe.NomUtilisateur,
                PrenomEmploye = v.Employe.PrenomUtilisateur,
                Commentaire = v.Commentaire,
                DateMouvement = v.DateMouvement
                };

            venteDTO.DetailMouvementStocks = _detailMouvementStockService.getDetailByMouvementId(v.Id);

            return venteDTO;
        }
    }
}
