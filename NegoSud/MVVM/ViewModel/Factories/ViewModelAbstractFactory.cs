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
        private readonly IViewModelFactory<InventaireViewModel> _InventaireViewModelFactory;

        public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<ProductsViewModel> productsViewModelFactory,
            IViewModelFactory<LoginViewModel> loginFormViewModelFactory,
            IViewModelFactory<DomaineViewModel> domaineViewModelFactory,
            IViewModelFactory<VentesViewModel> ventesViewModelFactory,
            IViewModelFactory<EmployesViewModel> employesViewModelFactory,
            IViewModelFactory<InventaireViewModel> inventaireViewModelFactory)
        {
            _HomeViewModelFactory = homeViewModelFactory;
            _ProductsViewModelFactory = productsViewModelFactory;
            _LoginViewModelFactory = loginFormViewModelFactory;
            _DomaineViewModelFactory = domaineViewModelFactory;
            _EmployesViewModelFactory = employesViewModelFactory;
            _VentesViewModelFactory = ventesViewModelFactory;
            _InventaireViewModelFactory = inventaireViewModelFactory;
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
                case ViewType.Inventaire:
                    return _InventaireViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("View Type does not have an existing View Model", "viewType");
            }
        }
    }
}
