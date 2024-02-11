using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NegoSud.MVVM.ViewModel
{
    public class ProductsItemViewModel : Item
    {
        public ProduitLightDTO ProduitLightDTO { get; set; }

        public ProductsItemViewModel(ProduitLightDTO produit)
        {
            ProduitLightDTO = produit;
            //ClickDeleteCommand = new RelayCommand(ClickDelete);
            ClickModifyCommand = new RelayCommand(ClickModify);
        }

        private void ClickModify(object obj)
        {
            //modify.Invoke(this.EmployeDTO, EventArgs.Empty);
            base.invoke_Modify(this);
        }


    }
}