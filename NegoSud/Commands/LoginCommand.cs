using NegoSud.MVVM.View;
using NegoSud.MVVM.ViewModel;
using NegoSud.Services.Authenticator;
using NegoSud.Services.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.Commands
{
    public class LoginCommand : ICommand
    {
        //private readonly LoginFormViewModel _lfvm;
        private readonly LoginViewModel _lfvm;
        private readonly IAuthenticator _authenticator;
        private readonly IRedirection _redirector;

        //public LoginCommand(LoginFormViewModel lfvm, IAuthenticator authenticator)
        //{
        //    _lfvm = lfvm;
        //    _authenticator = authenticator;
        //}

        public LoginCommand(LoginViewModel lfvm, IAuthenticator authenticator, IRedirection redirector)
        {
            _lfvm = lfvm;
            _authenticator = authenticator;
            _redirector = redirector;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            bool success = await _authenticator.Login(_lfvm.UserName, _lfvm.Password);

            if(success)
            {
                _redirector.Redirect();
            }
        }
    }   
}
