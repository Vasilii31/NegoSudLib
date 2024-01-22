using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Repositories
{
    public class DetailMvtRepository : BaseRepository, IDetailMvtRepository
    {
        public DetailMvtRepository(NegoSudDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DetailMouvementStock?>> GetByMvt(int id)
        {
            return await _context.DetailsMouvementStock
                 .Where(mvt => mvt.MouvementStockId == id)
                 .ToListAsync();
        }

        public async Task<DetailMouvementStock?> Post(DetailMouvementStock detailMvt){
            await _context.DetailsMouvementStock.AddAsync(detailMvt);
            await _context.SaveChangesAsync();
            return detailMvt;
        }

        public async Task<DetailMouvementStock?> Put(DetailMouvementStock detailMvt)
        {
            var result = await _context.DetailsMouvementStock
                .FirstOrDefaultAsync(mvt => mvt.Id == detailMvt.Id);

            if (result != null)
            {
                result.ProduitId = detailMvt.ProduitId;
                result.QteProduit = detailMvt.QteProduit;
                result.AuCarton = detailMvt.AuCarton;
                result.PrixApresRistourne = detailMvt.PrixApresRistourne;               
                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }

         public async Task Delete(int id)
        {
            var result = await _context.MouvementStocks
                .FirstOrDefaultAsync(mvt => mvt.Id == id);
            if (result != null)
            {
                _context.MouvementStocks.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.MouvementStocks.AnyAsync(mvt => mvt.Id == id);
        }
    }
}
