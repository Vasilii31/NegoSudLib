using Microsoft.EntityFrameworkCore.Infrastructure;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Extensions
{
    public static class AutreMvtExtension
    {
        public static AutreMvtDTO ToDTO(this AutreMouvement autreMvt)
        {


            AutreMvtDTO comDTO = new AutreMvtDTO
            {
                Id = autreMvt.Id,
                DateMouvement = autreMvt.DateMouvement,
                Commentaire = autreMvt.Commentaire,             
                NomEmploye = autreMvt.Employe.NomUtilisateur,
                PrenomEmploye = autreMvt.Employe.PrenomUtilisateur,
                TypeMouvement = autreMvt.TypeMouvement,
                TypeMouvementId = autreMvt.TypeMouvementId,
                DetailMouvementStocks = []
            };

            // on met à jour les DetailMouvementStock avec les prix à la date de la commande
            if (autreMvt.DetailMouvementStocks != null)
            {
                foreach (var mvt in autreMvt.DetailMouvementStocks)
                {
                    var mvtDTO = mvt.ToDTO(autreMvt.DateMouvement);
                    if (mvtDTO != null)
                    {
                        comDTO.DetailMouvementStocks = comDTO.DetailMouvementStocks.Append(mvtDTO);
                    }
                }
            }

            return comDTO;
        }


    }
}
