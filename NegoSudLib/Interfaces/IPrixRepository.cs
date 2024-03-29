﻿using NegoSudLib.DAO;

namespace NegoSudLib.Interfaces
{
    public interface IPrixRepository
    {
        #region PrixAchat
        Task<PrixAchat?> GetLastPrixAchat(int produitId);
        Task<PrixAchat?> GetPrixAchatByDate(int produitId, DateTime date);
        Task<PrixAchat?> PostPrixAchat(PrixAchat prix);
        Task<PrixAchat?> PutPrixAchat(PrixAchat prix);
        #endregion


        #region PrixVente
        Task<PrixVente?> GetLastPrixVente(int produitId);
        Task<PrixVente?> GetPrixVenteByDate(int produitId, DateTime date);
        Task<PrixVente?> PostPrixVente(PrixVente prix);
        Task<PrixVente?> PutPrixVente(PrixVente prix);
        #endregion
    }

}
