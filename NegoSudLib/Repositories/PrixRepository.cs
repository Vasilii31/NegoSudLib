using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Repositories
{
    public class PrixRepository : BaseRepository, IPrixRepository
    {
        private readonly NegoSudDBContext _context;

        public PrixRepository(NegoSudDBContext context) : base(context)
        {
            _context = context;
        }
        #region PrixAchat

        public async Task<PrixAchat?> GetLastPrixAchat(int produitId)
        {
            return await _context.PrixAchats
                    .Where(prix => (prix.ProduitId == produitId && prix.DateFin == null))
                    .FirstOrDefaultAsync();
        }
        public async Task<PrixAchat?> GetPrixAchatByDate(int produitId, DateTime date)
        {
            return await _context.PrixAchats
                .Where(prix => (prix.ProduitId == produitId && prix.DateDebut < date && (prix.DateFin == null || prix.DateFin < date)))
                .FirstOrDefaultAsync();
        }
        public async Task<PrixAchat?> PostPrixAchat(PrixAchat prix)
        {
            await _context.PrixAchats.AddAsync(prix);
            await _context.SaveChangesAsync();
            return prix;
        }
        public async Task<PrixAchat?> PutPrixAchat(PrixAchat prix)
        {
            _context.PrixAchats.Update(prix);
            await _context.SaveChangesAsync();
            return prix;
        }


        #endregion
        #region Prix Ventes
        public async Task<PrixVente?> GetLastPrixVente(int produitId)
        {
            return await _context.PrixVentes
                    .Where(prix => (prix.ProduitId == produitId && prix.DateFin == null))
                    .FirstOrDefaultAsync();
        }
        public async Task<PrixVente?> GetPrixVenteByDate(int produitId, DateTime date)
        {
            return await _context.PrixVentes
                .Where(prix => (prix.ProduitId == produitId && prix.DateDebut < date && (prix.DateFin == null || prix.DateFin < date)))
                .FirstOrDefaultAsync();
        }
        public async Task<PrixVente?> PostPrixVente(PrixVente prix)
        {
            await _context.PrixVentes.AddAsync(prix);
            await _context.SaveChangesAsync();
            return prix;
        }
        public async Task<PrixVente?> PutPrixVente(PrixVente prix)
        {
            _context.PrixVentes.Update(prix);
            await _context.SaveChangesAsync();
            return prix;
        }

        #endregion
    }
}
