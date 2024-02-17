using NegoSud.Core;
using NegoSud.MVVM.View.Tabs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class HistoriqueViewModel : ViewModelBase
    {
        public ICommand VentesTabCommande { get; set; }
        public ICommand CommandesTabCommande { get; set; }
        public ICommand AutresMvtTabCommande { get; set; }
        public int TabIndex { get; set; }
        public ObservableCollection<TabItem> ListTabs { get; set; } = new();

        private bool cmdAffiche = false;
        private bool venteAffiche = false;
        private bool autreMvtAffiche = false;

        public HistoriqueViewModel() 
        {
            VentesTabCommande = new RelayCommand(VenteTab_Open);
            CommandesTabCommande = new RelayCommand(CommandeTab_Open);
            AutresMvtTabCommande = new RelayCommand(AutresMvtTabCommande_Open);
        }

        private void AfficherTab(UserControl uc, string Title)
        {
            var tab = new TabItem();
            tab.Content = uc;
            tab.Header = Title;

            ListTabs.Add(tab);
            OnPropertyChanged(nameof(ListTabs));
            TabIndex = ListTabs.Count - 1;
            OnPropertyChanged(nameof(TabIndex));
        }

        private void AutresMvtTabCommande_Open(object obj)
        {
            if(autreMvtAffiche) { return; } 

            var uc = new AutresMvtHistoriqueTab();
            uc.DataContext = new AutresMvtHistoriqueViewModel();
            AfficherTab(uc, " Historique des Autres mouvements");
            autreMvtAffiche = true;
        }

        private void CommandeTab_Open(object obj)
        {
            if(cmdAffiche) { return; }

            var uc = new CommandesHistoriqueTab();
            uc.DataContext = new CommandesHistoriqueViewModel();
            AfficherTab(uc, " Historique des Commandes");
            cmdAffiche = true;
        }

        private void VenteTab_Open(object obj)
        {
            if(venteAffiche) { return;  }

            var uc = new VentesHistoriqueTab();
            uc.DataContext = new VentesHistoriqueViewModel();
            AfficherTab(uc, " Historique des Ventes");
            venteAffiche = true;
        }
    }
}
