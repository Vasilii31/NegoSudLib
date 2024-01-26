using NegoSudLib.DTO;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.Model
{
    public class EmployeAccount
    {

        public int Id { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public EmployeAccount(EmployeDTO employe)
        {
            Id = employe.Id;
            Email = employe.MailUtilisateur;
            //Password = password;
        }

    }
}
