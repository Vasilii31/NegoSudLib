using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudLib.Interfaces;

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
            var com = await _autreMvtRepository.GetById(id);
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
        public async Task<AutreMvtDTO?> Post(AutreMvtWriteDTO autreMvt)
        {
            var mvtAdded = await _autreMvtRepository.Post(autreMvt);
            if (mvtAdded == null) { return null; }
            foreach (var lgnVente in mvtAdded.DetailMouvementStocks)
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
                    pdtWrite.QteEnStock += pdtWrite.QteCarton * lgnVente.QteProduit;
                }
                else
                {
                    pdtWrite.QteEnStock += lgnVente.QteProduit;
                }
                var result = await _produitService.Put(lgnVente.ProduitId, pdtWrite);

            }
            return mvtAdded;
        }

        public async Task<AutreMvtDTO?> Put(int id, AutreMvtWriteDTO autreMvt)
        {
            return await _autreMvtRepository.Put(id, autreMvt);
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
