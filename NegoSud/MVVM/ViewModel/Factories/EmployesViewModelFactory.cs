using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
    internal class EmployesViewModelFactory : IViewModelFactory<EmployesViewModel>
    {
        public EmployesViewModel CreateViewModel()
        {
            return new EmployesViewModel();
        }
    }
}
