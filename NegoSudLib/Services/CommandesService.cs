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
    public class CommandesService
    {
        private readonly NegoSudDBContext _context;
        private readonly DetailMouvementStockService _detailMouvementStockService;
        public CommandesService(NegoSudDBContext context)
        {
            _context = context;
            _detailMouvementStockService = new DetailMouvementStockService(context);
        }

        public ICollection<CommandeDTO>? getCommandesByEmploye(int employeId)
        {
            ICollection<CommandeDTO> commandes = _context.Commandes
                .Where(commande  => commande.EmployeId == employeId)
                .Select(commande => new CommandeDTO
                {
                    Id = commande.Id,
                    NumCommande = commande.NumCommande,
                    DateMouvement = commande.DateMouvement,
                    Commentaire = commande.Commentaire,
                    NomFournisseur = commande.Fournisseur.NomFournisseur,
                    StatutCommande = commande.StatutCommande,
                    NomEmploye = commande.Employe.NomUtilisateur,
                    PrenomEmploye = commande.Employe.PrenomUtilisateur,
                })
                .ToList();
            if (commandes.Count == 0) { return null; }
            foreach (var commande in commandes)
            {
                commande.DetailMouvementStocks = _detailMouvementStockService.getDetailByMouvementId(commande.Id);
            }
            return commandes;
        }

       
    }
}
