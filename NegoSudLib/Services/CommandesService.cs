using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.write;
using NegoSudLib.DTO.Write;
using NegoSudLib.Interfaces;

namespace NegoSudLib.Services
{
    public class CommandesService : ICommandesService
    {
        private readonly ICommandesRepository _commandesRepository;
        private readonly IDetailMvtService _detMvtService;
        private readonly IProduitsServices _produitService;
        public CommandesService(ICommandesRepository commandesRepository, IDetailMvtService detMvtService, IProduitsServices produitService)
        {
            this._commandesRepository = commandesRepository;
            this._detMvtService = detMvtService;
            this._produitService = produitService;
        }
        public async Task<IEnumerable<CommandeDTO>> GetAll()
        {
            return await _commandesRepository.GetAll();
        }
        public async Task<IEnumerable<CommandeDTO>> GetByStatut(Statuts statut)
        {
            return await _commandesRepository.GetByStatut(statut);
        }
        public async Task<CommandeDTO?> GetById(int id)
        {
            var com = await _commandesRepository.GetById(id);
            if (com.DetailMouvementStocks.Any())
            {
                foreach (var DetMvt in com.DetailMouvementStocks)
                {
                    DetMvt.Produit = await _produitService.GetByIdDate(DetMvt.ProduitId, com.DateMouvement);
                }
            }
            com.SetTotaux();
            return com;
        }
        public async Task<CommandeDTO?> GetByNum(string num)
        {
            var com = await _commandesRepository.GetByNum(num);
            if (com.DetailMouvementStocks.Any())
            {
                foreach (var DetMvt in com.DetailMouvementStocks)
                {
                    DetMvt.Produit = await _produitService.GetByIdDate(DetMvt.ProduitId, com.DateMouvement);
                }
            }
            com.SetTotaux();
            return com;
        }
        public async Task<CommandeDTO?> Post(CommandeWriteDTO com)
        {
            var comAdded = await _commandesRepository.Post(com);
            if (comAdded == null) { return null; }
            foreach (var lgnVente in comAdded.DetailMouvementStocks)
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
            return comAdded;
        }

        public async Task<CommandeDTO?> Put(int id, CommandeWriteDTO com)
        {
            return await _commandesRepository.Put(id, com);
        }

        public async Task Delete(int id)
        {
            await _commandesRepository.Delete(id);
        }
        public async Task<bool> Exists(int id)
        {
            return await _commandesRepository.Exists(id);

        }
    }
}
