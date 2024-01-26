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
        private readonly IViewModelFactory<DomaineViewModel> _DomaineViewModelFactory;
        private readonly IViewModelFactory<FournisseurViewModel> _FournisseurViewModelFactory;

        public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<ProductsViewModel> productsViewModelFactory,
            IViewModelFactory<LoginViewModel> loginFormViewModelFactory,
            IViewModelFactory<DomaineViewModel> domaineViewModelFactory, 
            IViewModelFactory<EmployesViewModel> employesViewModelFactory,
            IViewModelFactory<FournisseurViewModel> fournisseurViewModel)
        {
            _HomeViewModelFactory = homeViewModelFactory;
            _ProductsViewModelFactory = productsViewModelFactory;
            _LoginViewModelFactory = loginFormViewModelFactory;
            _DomaineViewModelFactory = domaineViewModelFactory;
            _EmployesViewModelFactory = employesViewModelFactory;
            _FournisseurViewModelFactory = fournisseurViewModel;
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
                case ViewType.Domaines:
                    return _DomaineViewModelFactory.CreateViewModel();
                case ViewType.Fournisseurs:
                    return _FournisseurViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("View Type does not have an existing View Model", "viewType");
            }
        }
    }
}
