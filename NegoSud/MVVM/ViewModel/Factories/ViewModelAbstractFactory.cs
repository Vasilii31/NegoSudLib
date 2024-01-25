using NegoSud.Services.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _HomeViewModelFactory;
        private readonly IViewModelFactory<ProductsViewModel> _ProductsViewModelFactory;
        private readonly IViewModelFactory<LoginViewModel> _LoginViewModelFactory;
        private readonly IViewModelFactory<EmployesViewModel> _EmployesViewModelFactory;

        public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<ProductsViewModel> productsViewModelFactory, 
            IViewModelFactory<LoginViewModel> loginViewModelFactory,
            IViewModelFactory<EmployesViewModel> employesViewModelFactory)
        {
            _HomeViewModelFactory = homeViewModelFactory;
            _ProductsViewModelFactory = productsViewModelFactory;
            _LoginViewModelFactory = loginViewModelFactory;
            _EmployesViewModelFactory = employesViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _HomeViewModelFactory.CreateViewModel();
                case ViewType.Login:
                    return _LoginViewModelFactory.CreateViewModel();
                case ViewType.Products:
                    return _ProductsViewModelFactory.CreateViewModel();
                case ViewType.Employes:
                    return _EmployesViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("View Type does not have an existing View Model", "viewType");
            }
        }
    }
}
