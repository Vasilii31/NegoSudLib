using NegoSudLib.DTO.Read;
using System.Collections.ObjectModel;

namespace NegoSud.MVVM.ViewModel
{
    public class VentesViewModel : ViewModelBase
    {

        public VentesViewModel() { }

        public ObservableCollection<ProduitLightDTO> ListeProduits { get; set; }




    }
}
