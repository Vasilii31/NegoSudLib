using NegoSud.Services.Authenticator;
using NegoSud.Services.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
    public class LoginViewModelFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator authenticator;
        private readonly IRedirection redirector;

        public LoginViewModelFactory(IAuthenticator authenticator, IRedirection redirector)
        {
            this.authenticator = authenticator;
            this.redirector = redirector;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(authenticator, redirector);
        }
    }
}
