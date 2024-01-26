using Microsoft.EntityFrameworkCore.Metadata;
using NegoSud.Commands;
using NegoSud.Services.Authenticator;
using NegoSud.Services.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string userName;
        private string password;
        private bool _isViewVisible = true;
        private Visibility _failedAuth = Visibility.Collapsed;

        public Visibility FailedAuth
        {
            get { return _failedAuth; }
            set
            {
                _failedAuth = value;
                OnPropertyChanged(nameof(FailedAuth));
            }
        }

        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IRedirection redirector)
        {
            //LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);  
            LoginCommand = new LoginCommand(this, authenticator, redirector);

        }
    }
}
