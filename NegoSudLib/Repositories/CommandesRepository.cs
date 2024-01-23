using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                .Select(c=> c.ToDTO())
                .ToListAsync();
        }
        public async Task<IEnumerable<CommandeDTO>> GetByStatut(Statuts statut)
        {
            return await _context.Commandes
                .Include(c => c.Fournisseur)
                .Where(c => c.StatutCommande == statut)
                .Select(c=> c.ToDTO())
                .ToListAsync();
        }

        public async Task<CommandeDTO?> GetById(int id)
        {
            var commande = await _context.Commandes
                 .Include(c => c.Fournisseur)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
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
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p=>p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p=>p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Include(c=> c.Employe)
                 .Where(c => c.NumCommande == num)
                 .Select(c => c.ToDTO())
                 .FirstOrDefaultAsync();
            if (commande == null) return null;
            // On calcule les Totaux
            commande.SetTotaux();
            return commande;
        }
        public async Task<CommandeDTO?> Post(Commande commande)
        {
            await _context.Commandes.AddAsync(commande);
            await _context.SaveChangesAsync();
            return await this.GetById(commande.Id);
        }

        public async Task<CommandeDTO?> Put(Commande commande)
        {
            var result = await _context.Commandes
                .FirstOrDefaultAsync(com => com.Id == commande.Id);

            if (result != null)
            {
                result.FournisseurId = commande.FournisseurId;
                result.NumCommande = commande.NumCommande;
                result.StatutCommande = commande.StatutCommande;
                result.EntreeOuSortie = commande.EntreeOuSortie;
                result.QteMouvement = commande.QteMouvement;
                result.Commentaire = commande.Commentaire;
                result.EmployeId = commande.EmployeId;
                result.DateMouvement = commande.DateMouvement;                
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
