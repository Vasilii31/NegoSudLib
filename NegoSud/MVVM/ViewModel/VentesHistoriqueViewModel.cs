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
    public class VentesHistoriqueViewModel : ViewModelBase
    {
        public ObservableCollection<ConsultVenteItemViewModel> ListeVentes { get; set; } = new();

        private Visibility _consultVenteVisible = Visibility.Hidden;

        public Visibility ConsultVenteVisible
        {
            get { return _consultVenteVisible; }
            set
            {
                _consultVenteVisible = value;
                OnPropertyChanged(nameof(ConsultVenteVisible));

            }
        }

        private List<DetailMouvementStockDTO> _currentListVente = new();

        public List<DetailMouvementStockDTO> CurrentListVente
        {
            get { return _currentListVente; }
            set
            {
                _currentListVente = value;
                OnPropertyChanged(nameof(CurrentListVente));

            }
        }

        private ConsultVenteItemViewModel _currentVente;
        public ConsultVenteItemViewModel CurrentVente
        {
            get { return _currentVente; }
            set
            {
                _currentVente = value;
                OnPropertyChanged(nameof(CurrentVente));

            }
        }

        public VentesHistoriqueViewModel()
        {
            CreateListeVentes();
        }

        private void CreateListeVentes()
        {
            ListeVentes.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetVentes();

            })
            .ContinueWith(t =>
            {
                foreach (var vente in t.Result)
                {
                    var item = new ConsultVenteItemViewModel(vente);
                    //item.deleted += Item_deleted;
                    //item.modify += Item_modifyPopup;
                    item.Ventes.SetTotaux();
                    item.ouvrirVenteForm += OuvrirForm;
                    ListeVentes.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OuvrirForm(object? sender, EventArgs e)
        {
            CurrentVente = (ConsultVenteItemViewModel)sender;
            CurrentListVente = CurrentVente.Ventes.DetailMouvementStocks.ToList();
            ConsultVenteVisible = Visibility.Visible;
        }

        internal void FermerConsult(object sender, RoutedEventArgs e)
        {
            CurrentVente = null;
            CurrentListVente.Clear();
            ConsultVenteVisible = Visibility.Hidden;
        }
    }
}
