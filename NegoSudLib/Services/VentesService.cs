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
        private readonly IProduitsRepository _produitRepository;
        public VentesService(IVentesRepository VentesRepository, IDetailMvtService detMvtService, IProduitsServices produitService, IProduitsRepository produitRepository)
        {
            this._ventesRepository = VentesRepository;
            this._detMvtService = detMvtService;
            this._produitService = produitService;
            this._produitRepository = produitRepository;
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
            var venteAdded = await _ventesRepository.Post(vente);
            if (venteAdded == null) { return null; }
            foreach (var lgnVente in venteAdded.DetailMouvementStocks)
            {

                var pdtWrite = new ProduitWriteDTO()
                {
                    Id = lgnVente.ProduitId,
                    NomProduit = lgnVente.Produit.NomProduit,
                    IdDomaine = lgnVente.Produit.IdDomaine,
                    IdCategorie = lgnVente.Produit.IdCategorie,
                    ContenanceCl = lgnVente.Produit.ContenanceCl,
                    QteEnStock = lgnVente.Produit.QteEnStock,
                    QteCarton = lgnVente.Produit.QteCarton,
                    DegreeAlcool = lgnVente.Produit.DegreeAlcool,
                    Millesime = lgnVente.Produit.Millesime,
                    PhotoProduitPath = lgnVente.Produit.PhotoProduitPath,
                    DescriptionProduit = lgnVente.Produit.DescriptionProduit,
                    SeuilCommandeMin = lgnVente.Produit.SeuilCommandeMin,
                    CommandeMin = lgnVente.Produit.CommandeMin,
                };
                if (lgnVente.AuCarton)
                {
                    pdtWrite.QteEnStock -= pdtWrite.QteCarton * lgnVente.QteProduit;
                }
                else
                {
                    pdtWrite.QteEnStock -= lgnVente.QteProduit;
                }
                var result = await _produitRepository.Put(lgnVente.ProduitId, pdtWrite);

            }

            return venteAdded;
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
