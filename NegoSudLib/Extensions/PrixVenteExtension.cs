using NegoSudLib.DAO;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Extensions
{
    public static class PrixVenteExtension
    {
        public static PrixVenteDTO ToDTO(this PrixVente prix)
        {
            return new PrixVenteDTO
            {
                Id = prix.Id,
                DateDebut = prix.DateDebut,
                DateFin = prix.DateFin,
                PrixCarton =   prix.PrixCarton,
                PrixUnite = prix.PrixUnite,
                ProduitId = prix.ProduitId,
                Promotion = prix.Promotion,
                Taxe = prix.Taxe
            };
        }
    }
}
