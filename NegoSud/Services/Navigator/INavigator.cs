using NegoSud.MVVM.ViewModel;

namespace NegoSud.Services.Navigator
{
    public enum ViewType
    {
        Home,
        Login,
        Domaines,
        Products,
        Employes,
        Ventes,
        Inventaire,
        Cmd,
        Historique
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
