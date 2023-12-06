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

        public void addPrixAchat(PrixAchatDTO prixAchat)
        {
            // On modifie l'ancien prix d'achat s'il existe
            PrixAchat? AncienPrixAchat = _context.PrixAchats
                .Where(prix => prix.ProduitId == prixAchat.ProduitId && prix.FournisseurId == prixAchat.FournisseurId && prixAchat.DateFin == null).FirstOrDefault();

            if (AncienPrixAchat != null)
            {
                AncienPrixAchat.DateFin = DateTime.Now;
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
        
        
    }
}
