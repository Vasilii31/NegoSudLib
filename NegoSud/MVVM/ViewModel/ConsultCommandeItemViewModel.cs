using NegoSud.Core;
using NegoSudLib.DAO;
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
    public class ConsultCommandeItemViewModel : ViewModelBase
    {

        public CommandeDTO Commande { get; set; }

        public string DateCommande { get; set; }
        public string CommandeDuDate { get; set; }
        //public string EtatCommande { get; set; }

        public event EventHandler ouvrirVenteForm;
        
        public ICommand OuvrirDetailsCommandeCommand { get; set; }

        public ConsultCommandeItemViewModel(CommandeDTO commande)
        {
            Commande = commande;
            
            //EtatCommande = GetStatusToString(Commande.StatutCommande); 
            DateCommande = Commande.DateMouvement.Day.ToString() + '/' + Commande.DateMouvement.Month.ToString() + '/' + Commande.DateMouvement.Year.ToString();
            CommandeDuDate = "Commande du " + DateCommande;
            OuvrirDetailsCommandeCommand = new RelayCommand(OuvrirDetailsCommande);
        }

        private string? GetStatusToString(Statuts statutCommande)
        {
            switch(statutCommande)
            {
                case Statuts.AVALIDER:
                    return "A valider";
                case Statuts.RECU:
                    return "Reçue";
                case Statuts.ENPREPARATION:
                    return "En préparation";
                case Statuts.ENVOYE:
                    return "Envoyée";
                case Statuts.ANNULE:
                    return "Annulée";
                default:
                    return "Statut inconnu";
            }
        }

        private void OuvrirDetailsCommande(object sender)
        {
            ouvrirVenteForm?.Invoke(this, EventArgs.Empty);
        }

    }
}
