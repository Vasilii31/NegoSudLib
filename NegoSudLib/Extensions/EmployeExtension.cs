using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;

namespace NegoSudLib.Extensions
{
    public static class EmployeExtension
    {
        public static EmployeDTO ToDTO(this Employe emp, bool gerant)
        {

            EmployeDTO empDTO = new EmployeDTO
            {
                Id = emp.Id,
                UserName = emp.User.UserName,
                NomUtilisateur = emp.NomUtilisateur,
                PrenomUtilisateur = emp.PrenomUtilisateur,
                AdresseUtilisateur = emp.AdresseUtilisateur,
                MailUtilisateur = emp.User.Email,
                NumTelUtilisateur = emp.NumTelUtilisateur,
                Gerant = gerant
            };
            return empDTO;

        }

    }
}
