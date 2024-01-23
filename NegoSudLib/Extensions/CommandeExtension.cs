using Microsoft.EntityFrameworkCore.Infrastructure;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Extensions
{
    public static class CommandesExtension
    {
        public static CommandeDTO ToDTO(this Commande commande)
        {


            CommandeDTO comDTO = new CommandeDTO
            {
                Id = commande.Id,
                NumCommande = commande.NumCommande,
                DateMouvement = commande.DateMouvement,
                Commentaire = commande.Commentaire,             
                StatutCommande = commande.StatutCommande,
                NomEmploye = commande.Employe.NomUtilisateur,
                PrenomEmploye = commande.Employe.PrenomUtilisateur,
                NomFournisseur = commande.Fournisseur.NomFournisseur,
                DetailMouvementStocks = []
            };

            // on met à jour les DetailMouvementStock avec les prix à la date de la commande
            if (commande.DetailMouvementStocks != null)
            {
                foreach (var mvt in commande.DetailMouvementStocks)
                {
                    var mvtDTO = mvt.ToDTO(commande.DateMouvement);
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
