using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
    public class CategoriesViewModelFactory : IViewModelFactory<CategoriesViewModel>
    {
        public CategoriesViewModel CreateViewModel()
        {
            return new CategoriesViewModel();
        }
    }
}
