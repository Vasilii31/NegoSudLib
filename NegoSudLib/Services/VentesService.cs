using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudLib.Interfaces;

namespace NegoSudLib.Services
{
    public class VentesService : IVentesService
    {
        private readonly IVentesRepository _ventesRepository;
        private readonly IDetailMvtService _detMvtService;
        private readonly IProduitsServices _produitService;
        public VentesService(IVentesRepository VentesRepository, IDetailMvtService detMvtService, IProduitsServices produitService)
        {
            this._ventesRepository = VentesRepository;
            this._detMvtService = detMvtService;
            this._produitService = produitService;
        }
        public async Task<IEnumerable<VentesDTO>> GetAll()
        {
            return await _ventesRepository.GetAll();
        }
        public async Task<VentesDTO?> GetById(int id)
        {
            var com = await _ventesRepository.GetById(id);
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
        public async Task<VentesDTO?> GetByNum(string num)
        {
            var com = await _ventesRepository.GetByNum(num);
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
        public async Task<VentesDTO?> Post(VentesWriteDTO vente)
        {
            var comAdded = await _ventesRepository.Post(vente);
            if (comAdded == null) { return null; }
            return comAdded;
        }

        public async Task<VentesDTO?> Put(int id, VentesWriteDTO vente)
        {
            return await _ventesRepository.Put(id, vente);
        }

        public async Task Delete(int id)
        {
            await _ventesRepository.Delete(id);
        }
        public async Task<bool> Exists(int id)
        {
            return await _ventesRepository.Exists(id);

        }
    }
}
