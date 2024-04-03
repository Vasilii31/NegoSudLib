using NegoSudLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
	public interface IInventaireRepository
	{
		Task<IEnumerable<Inventaire>> GetAll(bool? validated);

		Task<Inventaire?> GetById(int id);
		Task<Inventaire?> Post(Inventaire inventaire);
		Task<Inventaire?> Put(int id, Inventaire inventaire);
		Task Delete(int id);

		Task<Inventaire> GetLatest();
	}
}
