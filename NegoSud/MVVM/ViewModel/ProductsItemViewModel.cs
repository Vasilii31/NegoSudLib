using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
    public class ProductsItemViewModel : Item
    {
        public ProduitLightDTO ProduitLightDTO { get; set;}

        public ProductsItemViewModel(ProduitLightDTO produit)
        {
            ProduitLightDTO = produit;
        }
    }
}
