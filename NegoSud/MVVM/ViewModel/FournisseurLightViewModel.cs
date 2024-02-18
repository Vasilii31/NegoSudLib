using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NegoSudLib.DTO.Read;

namespace NegoSud.MVVM.ViewModel
{
    public class FournisseurLightViewModel : ViewModelBase
    {
        public FournisseurDetailDTO Fournisseur { get; set; }

        public FournisseurLightViewModel(FournisseurDetailDTO fournisseur)
        {
            Fournisseur = fournisseur;
        }
    }
}
