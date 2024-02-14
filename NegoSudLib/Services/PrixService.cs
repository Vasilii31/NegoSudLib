using NegoSudLib.DAO;
using NegoSudLib.Interfaces;

namespace NegoSudLib.Services
{
    public class PrixService : IPrixService

    {
        private readonly IPrixRepository _prixRepository;
        public PrixService(IPrixRepository prixRepository)
        {
            this._prixRepository = prixRepository;
        }

        #region Prix Achat
        public async Task<PrixAchat?> PostPrixAchat(PrixAchat prix)
        {
            // On modifie l'ancien prix d'achat s'il existe
            var PrixAchatOld = await _prixRepository.GetLastPrixAchat(prix.ProduitId);
            if (PrixAchatOld != null)
            {
                PrixAchatOld.DateFin = DateTime.Now;
                await _prixRepository.PutPrixAchat(PrixAchatOld);
            }

            // On ajoute le nouveau prix
            return await _prixRepository.PostPrixAchat(prix);
        }

        public async Task<PrixAchat?> GetPrixAchatByDate(int produitId, DateTime date)
        {
            return await _prixRepository.GetPrixAchatByDate(produitId, date);
        }
        #endregion
        #region Prix Vente
        public async Task<PrixVente?> PostPrixVente(PrixVente prix)
        {
            // On modifie l'ancien prix de vente s'il existe
            PrixVente? PrixVenteOld = await _prixRepository.GetLastPrixVente(prix.ProduitId);
            if (PrixVenteOld != null)
            {
                PrixVenteOld.DateFin = DateTime.Now;
                await _prixRepository.PutPrixVente(PrixVenteOld);
            }

            // On ajoute le nouveau prix
            return await _prixRepository.PostPrixVente(prix);
        }

        public async Task<PrixVente?> GetPrixVenteByDate(int produitId, DateTime date)
        {
            return await _prixRepository.GetPrixVenteByDate(produitId, date);
        }
        #endregion

    }
}
