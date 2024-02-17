using NegoSud.Services;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NegoSud.MVVM.ViewModel
{
    public class CommandesHistoriqueViewModel : ViewModelBase
    {
        public ObservableCollection<ConsultCommandeItemViewModel> ListeCommandes { get; set; } = new();

        private ConsultCommandeItemViewModel _currentCommande;

        public ConsultCommandeItemViewModel CurrentCommande
        {
            get { return _currentCommande; }
            set
            {
                _currentCommande = value;
                OnPropertyChanged(nameof(CurrentCommande));

            }
        }

        private List<DetailMouvementStockDTO> _currentListMvt = new();

        public List<DetailMouvementStockDTO> CurrentListMvt
        {
            get { return _currentListMvt; }
            set
            {
                _currentListMvt = value;
                OnPropertyChanged(nameof(CurrentListMvt));

            }
        }


        private Visibility _consultCommandeVisible = Visibility.Hidden;

        public Visibility ConsultCommandeVisible
        {
            get { return _consultCommandeVisible; }
            set
            {
                _consultCommandeVisible = value;
                OnPropertyChanged(nameof(ConsultCommandeVisible));

            }
        }

        public CommandesHistoriqueViewModel()
        {
            CreateListeCommandes();
        }

        private void CreateListeCommandes()
        {
            ListeCommandes.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetCommandes();

            })
            .ContinueWith(t =>
            {
                foreach (var commande in t.Result)
                {
                    var item = new ConsultCommandeItemViewModel(commande);
                    //item.deleted += Item_deleted;
                    //item.modify += Item_modifyPopup;
                    item.Commande.SetTotaux();
                    item.ouvrirVenteForm += OuvrirForm;
                    ListeCommandes.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OuvrirForm(object? sender, EventArgs e)
        {

            CurrentCommande = (ConsultCommandeItemViewModel)sender;
            CurrentListMvt = CurrentCommande.Commande.DetailMouvementStocks.ToList();

            ConsultCommandeVisible = Visibility.Visible;
        }

        internal void FermerConsult(object sender, RoutedEventArgs e)
        {
            CurrentCommande = null;
            CurrentListMvt.Clear();
            ConsultCommandeVisible = Visibility.Hidden;
        }
    }
}
