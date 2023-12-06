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
    public class PrixVenteService
    {
        private readonly NegoSudDBContext _context;

        public PrixVenteService(NegoSudDBContext context)
        {
            _context = context;
        }

        public void addPrixVente(PrixVenteDTO prixVente)
        {
            // On modifie l'ancien prix de vente s'il existe
            PrixVente? AncienPrixVente = _context.PrixVentes
                .Where(prix => prix.ProduitId == prixVente.ProduitId && prixVente.DateFin == null).FirstOrDefault();

            if (AncienPrixVente != null)
            {
                AncienPrixVente.DateFin = DateTime.Now;
                _context.SaveChanges();
            }

            // On ajoute le nouveau prix

            PrixVente PrixVenteEntity = new PrixVente
            {
                DateDebut = prixVente.DateDebut,
                DateFin = null,
                PrixCarton = prixVente.PrixCarton,
                PrixUnite = prixVente.PrixUnite,
                ProduitId = prixVente.ProduitId,
                Taxe = prixVente.Taxe
            };
            _context.PrixVentes.Add(PrixVenteEntity);
            _context.SaveChanges();
        }
        
        
    }
}
