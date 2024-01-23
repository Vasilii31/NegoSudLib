using NegoSud.Commands;
using NegoSud.Core;
using NegoSud.MVVM.ViewModel.Factories;
using NegoSud.Services.Authenticator;
using NegoSud.Services.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IViewModelAbstractFactory _factory;

        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IViewModelAbstractFactory viewModelFactory, IAuthenticator authenticator) 
        {
            Navigator = navigator;
            Authenticator = authenticator;
            _factory = viewModelFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _factory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
        
    }
}
