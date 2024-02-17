using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.write;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;

namespace NegoSudLib.Repositories
{
    public class CommandesRepository : BaseRepository, ICommandesRepository
    {
        public CommandesRepository(NegoSudDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CommandeDTO>> GetAll()
        {
            return await _context.Commandes
                .Include(c => c.Fournisseur)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Categorie)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Domaine)
                 .Include(c => c.Employe)
                .Select(c => c.ToDTO())
                .ToListAsync();
        }
        public async Task<IEnumerable<CommandeDTO>> GetByStatut(Statuts statut)
        {
            return await _context.Commandes.
                Include(c => c.Fournisseur)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Categorie)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Domaine)
                 .Include(c => c.Employe)
                .Where(c => c.StatutCommande == statut)
                .Select(c => c.ToDTO())
                .ToListAsync();
        }

        public async Task<CommandeDTO?> GetById(int id)
        {
            var commande = await _context.Commandes
                 .Include(c => c.Fournisseur)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                  .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Categorie)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Domaine)
                 .Include(c => c.Employe)
                 .Where(c => c.Id == id)
                 .Select(c => c.ToDTO())
                 .FirstOrDefaultAsync();
            if (commande == null) return null;
            commande.SetTotaux();
            return commande;
        }
        public async Task<CommandeDTO?> GetByNum(string num)
        {
            var commande = await _context.Commandes
                 .Include(c => c.Fournisseur)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                  .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Categorie)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Domaine)
                 .Include(c => c.Employe)
                 .Where(c => c.NumCommande == num)
                 .Select(c => c.ToDTO())
                 .FirstOrDefaultAsync();
            if (commande == null) return null;
            // On calcule les Totaux
            commande.SetTotaux();
            return commande;
        }
        public async Task<CommandeDTO?> Post(CommandeWriteDTO commandeDTO)
        {
            List<DetailMouvementStock> DetailMvt = [];
            foreach (var item in commandeDTO.DetailMouvementStocks)
            {
                DetailMvt.Add(item.ToDAO());
            }
            Commande commande = new Commande
            {
                DateMouvement = DateTime.Now,
                EmployeId = commandeDTO.EmployeId,
                FournisseurId = commandeDTO.FournisseurId,
                StatutCommande = commandeDTO.StatutCommande,
                EntreeOuSortie = true,
                DetailMouvementStocks = DetailMvt,
                Commentaire = commandeDTO.Commentaire
            };
            await _context.Commandes.AddAsync(commande);
            await _context.SaveChangesAsync();
            commande.NumCommande = "COM" + commande.Id;
            await _context.SaveChangesAsync();
            return await GetById(commande.Id);
        }

        public async Task<CommandeDTO?> Put(int id, CommandeWriteDTO commande)
        {
            var result = await _context.Commandes.FindAsync(id);

            if (result != null)
            {
                result.FournisseurId = commande.FournisseurId;
                result.StatutCommande = commande.StatutCommande;
                result.Commentaire = commande.Commentaire;
                result.EmployeId = commande.EmployeId;
                await _context.SaveChangesAsync();
                var resultDTO = result.ToDTO();
                resultDTO.SetTotaux();
                return resultDTO;
            }
            return null;
        }
        public async Task Delete(int id)
        {
            var commnande = await _context.Commandes.FindAsync(id);

            if (commnande != null)
            {
                _context.Commandes.Remove(commnande);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.Commandes.AnyAsync(c => c.Id == id);
        }
    }
}
