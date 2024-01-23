using NegoSudLib.DAO;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Extensions
{
    public static class ClientExtension
    {
        public static ClientDTO toDTO(this Client cli)
        {
            return new ClientDTO
            {
               Id = cli.Id,
               NomUtilisateur = cli.NomUtilisateur,
               PrenomUtilisateur = cli.PrenomUtilisateur,
               AdresseUtilisateur = cli.AdresseUtilisateur,
               MailUtilisateur  = cli.MailUtilisateur,
               NumTelUtilisateur =  cli.NumTelUtilisateur,
               NumClient= cli.NumClient,
               HMotDePasse = cli.HMotDePasse
            };
        }
    }
}
