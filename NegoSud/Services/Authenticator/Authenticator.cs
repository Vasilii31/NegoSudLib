using NegoSud.Core;
using NegoSud.MVVM.Model;
using NegoSud.Services.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.Services.Authenticator
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthentificationService _authentificationService;

        public Authenticator(IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }
        

        private EmployeAccount _currentAccount;
        public EmployeAccount CurrentAccount 
        {
            get
            {
                return _currentAccount;
            }
            private set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentAccount));
                OnPropertyChanged(nameof(isLoggedIn));

            }
        }
        public bool isLoggedIn => CurrentAccount != null;

        public async Task<bool> Login(string email, string password)
        {
            bool success = true;
            try
            {
                CurrentAccount = await _authentificationService.Login(email, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }
    }
}
