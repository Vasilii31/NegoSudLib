using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<ProductsViewModel> ListeProduits { get; set; } = new();
        public int NombreEmployes { get => ListeProduits.Count(); }
    }
}
