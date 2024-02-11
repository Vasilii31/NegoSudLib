using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;

namespace NegoSudLib.Extensions
{
    public static class ClientExtension
    {
        public static ClientDTO toDTO(this Client cli)
        {
            return new ClientDTO
            {
                Id = cli.Id,
                UserName = cli.User.UserName,
                NomUtilisateur = cli.NomUtilisateur,
                PrenomUtilisateur = cli.PrenomUtilisateur,
                AdresseUtilisateur = cli.AdresseUtilisateur,
                MailUtilisateur = cli.User.Email,
                NumTelUtilisateur = cli.NumTelUtilisateur,
                NumClient = cli.NumClient
            };
        }
    }
}
