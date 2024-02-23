using NegoSudLib.DAO;
using NegoSudLib.DTO.Write;
using NegoSudLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Services
{
	public class InventaireService : IInventaireService
	{
		private readonly IInventaireRepository _repository;
		private readonly IAutreMvtService _mvtService;

		public InventaireService(IInventaireRepository repository, IAutreMvtService mvtService)
		{
			_repository = repository;
			_mvtService = mvtService;
		}

		public async Task<IEnumerable<Inventaire>> GetAll(bool? validated)
		{
			return await _repository.GetAll(validated);
		}

		public async Task<Inventaire?> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public Task<Inventaire> GetLatest()
		{
			throw new NotImplementedException();
		}

		public async Task<Inventaire?> Post(Inventaire inventaire)
		{
			var invAdded = await _repository.Post(inventaire);
			if(invAdded == null) { return null; }
			//ajouter la gestion stock
			AutreMvtWriteDTO mvtWrite = new AutreMvtWriteDTO
			{
				DateMouvement = invAdded.DateInventaire,
				Commentaire = "Inventaire du" + invAdded.DateInventaire.ToString(),
				EntreeOuSortie = true,
				//a implémenter ?
				EmployeId = 1,
				TypeMouvementId = 1,
				DetailMouvementStocks = new List<DetailMouvementStock>()
			};

			foreach(var item in invAdded.LigneInventaires)
			{
				if(item.QuantiteAvantInventaire != item.QuantiteApresInventaire)
				{
					mvtWrite.DetailMouvementStocks.Add(new DetailMouvementStock
					{
						QteProduit = item.QuantiteApresInventaire - item.QuantiteAvantInventaire,
						PrixApresRistourne = 0,
						AuCarton = false,
						ProduitId = item.IdProduit
					});
				}
				
			}

			await _mvtService.Post(mvtWrite);

			return invAdded;
		}

		public Task<Inventaire?> Put(int id, Inventaire inventaire)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Exists(int id)
		{
			throw new NotImplementedException();
		}
	}
}
