using NegoSud.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.Services.Authenticator
{
    public interface IAuthenticator
    {
        EmployeAccount CurrentAccount { get; }
        bool isLoggedIn { get; }
        //Task<RegistrationResult> Register(string email, string password, string confirmPassword);
        Task<bool> Login(string email, string password);
        void Logout();


    }
}
