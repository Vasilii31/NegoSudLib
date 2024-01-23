using NegoSud.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.Services.Authentification
{
    public class AuthentificationService : IAuthentificationService
    {
        public async Task<EmployeAccount> Login(string email, string password)
        {
            //pour l'instant on fait ça pour tester le changement de vue
            return new EmployeAccount(0, email, password);
        }

        public async Task<bool> Register(string email, string password)
        {
            throw new NotImplementedException();
        }


    }
}
