using NegoSud.Core;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class ConsultAutreMvtItemViewModel : ViewModelBase
    {
        public AutreMvtDTO AutreMvtDTO { get; set; }

        public string DateAutreMvt { get; set; }
        public string AutreMvtDuDate { get; set; }
        //public string EtatCommande { get; set; }

        public event EventHandler ouvrirAutreMvtForm;

        public ICommand OuvrirDetailsAutreMvtCommand { get; set; }

        public ConsultAutreMvtItemViewModel(AutreMvtDTO autreMvt)
        {
            AutreMvtDTO = autreMvt;

            //EtatCommande = GetStatusToString(Commande.StatutCommande); 
            DateAutreMvt = AutreMvtDTO.DateMouvement.Day.ToString() + '/' + AutreMvtDTO.DateMouvement.Month.ToString() + '/' + AutreMvtDTO.DateMouvement.Year.ToString();
            AutreMvtDuDate = "Autre mouvement du " + DateAutreMvt;
            OuvrirDetailsAutreMvtCommand = new RelayCommand(OuvrirDetailsAutreMouvement);
        }


        private void OuvrirDetailsAutreMouvement(object sender)
        {
            ouvrirAutreMvtForm?.Invoke(this, EventArgs.Empty);
        }
    }
}
