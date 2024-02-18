using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
    internal class InventaireViewModelFactory : IViewModelFactory<InventaireViewModel>
    {
        public InventaireViewModel CreateViewModel()
        {
            return new InventaireViewModel();
        }
    }
}
