using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;

namespace NegoSudLib.Extensions
{
    public static class DetailMouvementStockExtension
    {
        public static DetailMouvementStockDTO ToDTO(this DetailMouvementStock detMvt, DateTime date)
        {
            // on met a jour le produit a la date du mouvements
            ProduitLightDTO produitLightDTO = detMvt.Produit.ToLightDTO(date);
            return new DetailMouvementStockDTO
            {
                Id = detMvt.Id,
                QteProduit = detMvt.QteProduit,
                PrixApresRistourne = detMvt.PrixApresRistourne,
                AuCarton = detMvt.AuCarton,
                MouvementStockId = detMvt.MouvementStockId,
                ProduitId = detMvt.ProduitId,
                Produit = produitLightDTO
            };
        }


    }
}
