using NegoSud.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.Services.Authentification
{
    public interface IAuthentificationService
    {
        Task<bool> Register(string email, string password);
        Task<EmployeAccount> Login(string email, string password);

    }
}
