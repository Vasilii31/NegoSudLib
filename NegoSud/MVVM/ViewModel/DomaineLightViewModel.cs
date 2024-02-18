using NegoSud.Core;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NegoSud.MVVM.ViewModel
{
    public class DomaineLightViewModel : Item
    {
        public DomaineDTO Domaine { get; set; }

        public DomaineLightViewModel(DomaineDTO domaine)
        {
            Domaine = domaine;
            ClickModifyCommand = new RelayCommand(ClickModify);
        }

        private void ClickModify(object obj)
        {
            
                base.invoke_Modify(this);
            
            
        }

    }
}
