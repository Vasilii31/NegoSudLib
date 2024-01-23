using NegoSud.Commands;
using NegoSud.Core;
using NegoSud.MVVM.ViewModel;
using NegoSud.MVVM.ViewModel.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.Services.Navigator
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        {
            get { return _currentViewModel; }
            set 
            {
                _currentViewModel = value; 
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}
