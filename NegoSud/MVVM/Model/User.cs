using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.Model
{
    public class User 
    {

        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public User()
        {
            
        }

        public bool VerifyPassword(string inputPwd)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(inputPwd, Password);
        }
    }
}
