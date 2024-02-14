namespace NegoSud.MVVM.ViewModel.Factories
{
    internal class CmdViewModelFactory : IViewModelFactory<CmdViewModel>
    {
        public CmdViewModel CreateViewModel()
        {
            return new CmdViewModel();
        }
    }
}
