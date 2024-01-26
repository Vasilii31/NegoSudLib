namespace NegoSud.MVVM.ViewModel.Factories
{
    internal class VentesViewModelFactory : IViewModelFactory<VentesViewModel>
    {
        public VentesViewModel CreateViewModel()
        {
            return new VentesViewModel();
        }
    }
}
