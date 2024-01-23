using Microsoft.EntityFrameworkCore.Infrastructure;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
