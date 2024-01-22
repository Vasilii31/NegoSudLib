using NegoSudLib.DAO;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Extensions
{
    public static class EmployeExtension
    {
        public static EmployeDetailDTO ToDTO(this Employe emp)
        {
            return new EmployeDetailDTO
            {
                Id = emp.Id,
               NomUtilisateur = emp.NomUtilisateur,
               PrenomUtilisateur = emp.PrenomUtilisateur,
               AdresseUtilisateur = emp.AdresseUtilisateur,
               MailUtilisateur  = emp.MailUtilisateur,
               NumTelUtilisateur =  emp.NumTelUtilisateur,
               Gerant = emp.Gerant
            };
        }
    }
}
