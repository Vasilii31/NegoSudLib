using NegoSudLib.DAO;

namespace NegoSudLib.Interfaces
{
    public interface IPrixService
    {
        #region PrixAchat
        Task<PrixAchat?> GetPrixAchatByDate(int produitId, DateTime date);
        Task<PrixAchat?> PostPrixAchat(PrixAchat prix);
        #endregion


        #region PrixVente
        Task<PrixVente?> GetPrixVenteByDate(int produitId, DateTime date);
        Task<PrixVente?> PostPrixVente(PrixVente prix);
        #endregion

    }
}