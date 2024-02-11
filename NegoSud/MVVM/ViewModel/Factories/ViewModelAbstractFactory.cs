using NegoSud.Services.Navigator;

namespace NegoSud.MVVM.ViewModel.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _HomeViewModelFactory;
        private readonly IViewModelFactory<ProductsViewModel> _ProductsViewModelFactory;
        private readonly IViewModelFactory<LoginViewModel> _LoginViewModelFactory;
        private readonly IViewModelFactory<EmployesViewModel> _EmployesViewModelFactory;
        private readonly IViewModelFactory<DomaineViewModel> _DomaineViewModelFactory;
        private readonly IViewModelFactory<VentesViewModel> _VentesViewModelFactory;

        public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<ProductsViewModel> productsViewModelFactory,
            IViewModelFactory<LoginViewModel> loginFormViewModelFactory,
            IViewModelFactory<DomaineViewModel> domaineViewModelFactory,
            IViewModelFactory<VentesViewModel> ventesViewModelFactory,
            IViewModelFactory<EmployesViewModel> employesViewModelFactory)
        {
            _HomeViewModelFactory = homeViewModelFactory;
            _ProductsViewModelFactory = productsViewModelFactory;
            _LoginViewModelFactory = loginFormViewModelFactory;
            _DomaineViewModelFactory = domaineViewModelFactory;
            _EmployesViewModelFactory = employesViewModelFactory;
            _VentesViewModelFactory = ventesViewModelFactory;
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
                case ViewType.Ventes:
                    return _VentesViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("View Type does not have an existing View Model", "viewType");
            }
        }
    }
}
