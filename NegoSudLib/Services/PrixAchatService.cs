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
    public class PrixAchatService
    {
        private readonly NegoSudDBContext _context;

        public PrixAchatService(NegoSudDBContext context)
        {
            _context = context;
        }

        public PrixAchatReadDTO? getPrixAchatActuel(int produitId) {
            return _context.PrixAchats
                .Where(prix => (prix.ProduitId == produitId && prix.DateFin == null))
                .Select(prix => new PrixAchatReadDTO
                {
                    Id = prix.Id,
                    ProduitId = prix.ProduitId,
                    PrixCarton = prix.PrixCarton,
                    PrixUnite = prix.PrixUnite,
                    DateDebut = prix.DateDebut,
                    DateFin = prix.DateFin,
                    Fournisseur = prix.Fournisseur
                })
                .FirstOrDefault();
        }

        public void addPrixAchat(PrixAchatWriteDTO prixAchat)
        {
            // On modifie l'ancien prix d'achat s'il existe
            PrixAchat? PrixAchatOld = _context.PrixAchats
                .Where(prix => prix.ProduitId == prixAchat.ProduitId && prix.FournisseurId == prixAchat.FournisseurId && prix.DateFin == null)
                .FirstOrDefault();

            if (PrixAchatOld != null)
            {
                PrixAchatOld.DateFin = DateTime.Now;
                _context.SaveChanges();
            }

            // On ajoute le nouveau prix
            PrixAchat PrixAchatEntity = new PrixAchat
            {
                DateDebut = prixAchat.DateDebut,
                DateFin = null,
                PrixCarton = prixAchat.PrixCarton,
                PrixUnite = prixAchat.PrixUnite,
                ProduitId = prixAchat.ProduitId,
                FournisseurId = prixAchat.FournisseurId
            };
            _context.PrixAchats.Add(PrixAchatEntity);
            _context.SaveChanges();
        }

        public PrixAchatReadDTO? getPrixAchatByDate(int produitId, DateTime date)
        {
            return _context.PrixAchats
                .Where(prix => (prix.ProduitId == produitId && prix.DateDebut < date && (prix.DateFin == null || prix.DateFin < date) ))
                .Select(prix => new PrixAchatReadDTO
                {
                    Id = prix.Id,
                    ProduitId = prix.ProduitId,
                    PrixCarton = prix.PrixCarton,
                    PrixUnite = prix.PrixUnite,
                    DateDebut = prix.DateDebut,
                    DateFin = prix.DateFin,
                    Fournisseur = prix.Fournisseur
                })
                .FirstOrDefault();
        }

    }
}
