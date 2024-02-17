using NegoSud.Core;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class ConsultVenteItemViewModel : ViewModelBase
    {
        public VentesDTO Ventes { get; set; }

        public string ClientFullName { get; set; }
        public string DateVente { get; set; }
        public string VenteDuDate { get; set; }

        public event EventHandler ouvrirVenteForm;

        public ICommand OuvrirDetailsVenteCommand { get; set; }

        public ConsultVenteItemViewModel(VentesDTO vente)
        {
            Ventes = vente;
            ClientFullName = vente.NomClient + ' ' + vente.PrenomClient;
            DateVente = vente.DateMouvement.Day.ToString() + '/' + vente.DateMouvement.Month.ToString() + '/' + vente.DateMouvement.Year.ToString();
            VenteDuDate = "Vente du " + DateVente;
            OuvrirDetailsVenteCommand = new RelayCommand(OuvrirDetailsVente);
        }

        private void OuvrirDetailsVente(object obk)
        {
            ouvrirVenteForm?.Invoke(this.Ventes, EventArgs.Empty);
        }

        
    }
}
