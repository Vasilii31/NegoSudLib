using BCrypt.Net;
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
            //string hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA384);
            //var hres = BCrypt.Net.BCrypt.EnhancedVerify(password, hash, HashType.SHA384);
            
            //pour l'instant on fait ça pour tester le changement de vue
            var employe = await httpClientService.GetEmployeByMail(email);
            if(employe.Id != 0)
            {
                //if (BCrypt.Net.BCrypt.EnhancedVerify(password, employe.HMotDePasse, HashType.SHA384))
                //{
                //    return new EmployeAccount(employe);
                //}
            }
            //var res = BCrypt.Net.BCrypt.EnhancedVerify(password, employe.HMotDePasse, HashType.SHA384);

            throw new Exception();
        }

        public async Task<bool> Register(string email, string password)
        {
            throw new NotImplementedException();
        }


    }
}
