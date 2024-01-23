using NegoSud.Services.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
    public class LoginFormViewModelFactory : IViewModelFactory<LoginFormViewModel>
    {
        private readonly IAuthenticator authenticator;

        public LoginFormViewModelFactory(IAuthenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        public LoginFormViewModel CreateViewModel()
        {
            return new LoginFormViewModel(authenticator);
        }
    }
}
