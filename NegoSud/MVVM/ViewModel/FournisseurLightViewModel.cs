using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NegoSud.Core;
using NegoSudLib.DTO.Read;

namespace NegoSud.MVVM.ViewModel
{
    public class FournisseurLightViewModel : Item
    {
        public FournisseurDetailDTO Fournisseur { get; set; }

        public FournisseurLightViewModel(FournisseurDetailDTO fournisseur)
        {
            Fournisseur = fournisseur;
            ClickModifyCommand = new RelayCommand(ClickModify);
        }

        private void ClickModify(object obj)
        {

            base.invoke_Modify(this);


        }
    }
}
