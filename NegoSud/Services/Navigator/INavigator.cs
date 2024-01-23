using NegoSud.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.Services.Navigator
{
    public enum ViewType
    {
        Home,
        Login,
        Products,
        Domaines
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
