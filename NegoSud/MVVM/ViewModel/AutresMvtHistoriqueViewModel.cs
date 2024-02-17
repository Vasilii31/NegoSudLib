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
    public class AutresMvtHistoriqueViewModel : ViewModelBase
    {

        public ObservableCollection<ConsultAutreMvtItemViewModel> ListeAutresMvt { get; set; } = new();

        public ObservableCollection<ConsultCommandeItemViewModel> ListeCommandes { get; set; } = new();

        private ConsultAutreMvtItemViewModel _currentAutreMvt;

        public ConsultAutreMvtItemViewModel CurrentAutreMvt
        {
            get { return _currentAutreMvt; }
            set
            {
                _currentAutreMvt = value;
                OnPropertyChanged(nameof(CurrentAutreMvt));

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

        private Visibility _consultAutreMvtVisible = Visibility.Hidden;

        public Visibility ConsultAutreMvtVisible
        {
            get { return _consultAutreMvtVisible; }
            set
            {
                _consultAutreMvtVisible = value;
                OnPropertyChanged(nameof(ConsultAutreMvtVisible));

            }
        }

        public AutresMvtHistoriqueViewModel()
        {
            CreateListeAutresMvt();
        }

        private void CreateListeAutresMvt()
        {
            ListeAutresMvt.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetAutresMvt();

            })
            .ContinueWith(t =>
            {
                foreach (var vente in t.Result)
                {
                    var item = new ConsultAutreMvtItemViewModel(vente);
                    //item.deleted += Item_deleted;
                    //item.modify += Item_modifyPopup;
                    item.AutreMvtDTO.SetTotaux();
                    item.ouvrirAutreMvtForm += OuvrirForm;
                    ListeAutresMvt.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OuvrirForm(object? sender, EventArgs e)
        {
            CurrentAutreMvt = (ConsultAutreMvtItemViewModel)sender;
            CurrentListMvt = CurrentAutreMvt.AutreMvtDTO.DetailMouvementStocks.ToList();
            ConsultAutreMvtVisible = Visibility.Visible;
        }

        internal void FermerConsult(object sender, RoutedEventArgs e)
        {
            CurrentAutreMvt = null;
            CurrentListMvt.Clear();
            ConsultAutreMvtVisible = Visibility.Hidden;
        }
    }
}
