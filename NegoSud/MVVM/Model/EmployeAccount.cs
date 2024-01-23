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
        public string Password { get; set; }
        public EmployeAccount(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

    }
}
