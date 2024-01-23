﻿using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public static class VentesExtension
    {
        public static VentesDTO ToDTO(this Vente vente)
        {


            VentesDTO comDTO = new VentesDTO
            {
                Id = vente.Id,
                DateMouvement = vente.DateMouvement,
                Commentaire = vente.Commentaire,             
                NomEmploye = vente.Employe.NomUtilisateur,
                PrenomEmploye = vente.Employe.PrenomUtilisateur,
                NumClient = vente.Client.NumClient,
                NomClient = vente.Client.NomUtilisateur,
                PrenomClient = vente.Client.PrenomUtilisateur,
                NumFacture = vente.NumFacture,
                DetailMouvementStocks = []
            };

            // on met à jour les DetailMouvementStock avec les prix à la date de la vente
            if (vente.DetailMouvementStocks != null)
            {
                foreach (var mvt in vente.DetailMouvementStocks)
                {
                    var mvtDTO = mvt.ToDTO(vente.DateMouvement);
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
