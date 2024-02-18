using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
    public class DomaineLightViewModel : ViewModelBase
    {
        public DomaineDTO Domaine { get; set; }


        public DomaineLightViewModel(DomaineDTO domaine)
        {
            Domaine = domaine;
        }

    }
}
