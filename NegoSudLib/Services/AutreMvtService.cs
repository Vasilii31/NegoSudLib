using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Services
{
    public class AutreMvtService : IAutreMvtService
    {
        private readonly IAutreMvtRepository _autreMvtRepository;
        private readonly IDetailMvtService _detMvtService;
        private readonly IProduitsServices _produitService;
        public AutreMvtService(IAutreMvtRepository autreMvtRepository, IDetailMvtService detMvtService, IProduitsServices produitService)
        {
            this._autreMvtRepository = autreMvtRepository;
            this._detMvtService = detMvtService;
            this._produitService = produitService;
        }
        public async Task<IEnumerable<AutreMvtDTO>> GetAll()
        {
            return await _autreMvtRepository.GetAll();
        }
        public async Task<AutreMvtDTO?> GetById(int id)
        {
          var com =  await _autreMvtRepository.GetById(id);
            if (com != null)
            {
                if (com.DetailMouvementStocks.Any())
                {
                    foreach (var DetMvt in com.DetailMouvementStocks)
                    {
                        DetMvt.Produit = await _produitService.GetByIdDate(DetMvt.ProduitId, com.DateMouvement);
                    }
                }
                com.SetTotaux();
            }
            return com;
        }
        public async Task<IEnumerable<AutreMvtDTO?>> GetByType(int typeId)
        {
           return await _autreMvtRepository.GetByType(typeId);
        }
        public async Task<AutreMvtDTO?> Post(AutreMouvement autreMvt)
        {
            var comAdded =  await _autreMvtRepository.Post(autreMvt);
            if (comAdded == null) { return null; }
            return comAdded;
        }

        public async Task<AutreMvtDTO?> Put(AutreMouvement autreMvt)
        {
            return await _autreMvtRepository.Put(autreMvt);
        }

        public async Task Delete(int id)
        {
            await _autreMvtRepository.Delete(id);
        }
        public async Task<bool> Exists(int id)
        {
            return await _autreMvtRepository.Exists(id);

        }
    }
}
