using NegoSud.MVVM.ViewModel;
using NegoSud.MVVM.ViewModel.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.Services.Navigator
{
    public class ViewModelFactoryRedirector<TViewModel> : IRedirection where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IViewModelFactory<TViewModel> _viewModelFactory;

        public ViewModelFactoryRedirector(INavigator navigator, IViewModelFactory<TViewModel> viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public void Redirect()
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel();
        }
    }
}
