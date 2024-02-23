using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Repositories
{
	public class InventaireRepository : BaseRepository, IInventaireRepository
	{
		public InventaireRepository(NegoSudDBContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Inventaire>> GetAll(bool? validated)
		{
			if (validated == null)
			{
				return await _context.Inventaires.ToListAsync();
			}
			return await _context.Inventaires.Where(p => p.IsValidated == validated).ToListAsync();

		}

		public async Task<Inventaire?> GetById(int id)
		{
			return await _context.Inventaires
				.Include(p => p.LigneInventaires)
					.ThenInclude(p => p.Produit)
				.Where(p => p.Id == id)
				.FirstOrDefaultAsync();
		}

		public Task<Inventaire> GetLatest()
		{
			throw new NotImplementedException();
		}

		public async Task<Inventaire?> Post(Inventaire inventaire)
		{
			await _context.Inventaires.AddAsync(inventaire);
			await _context.SaveChangesAsync();
			return await GetById(inventaire.Id);
		}

		public Task<Inventaire?> Put(int id, Inventaire inventaire)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
