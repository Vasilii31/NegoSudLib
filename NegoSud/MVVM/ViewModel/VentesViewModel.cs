using NegoSud.Services;
using NegoSudLib.DTO.Read;
using System.Collections.ObjectModel;
using System.Windows;

namespace NegoSud.MVVM.ViewModel
{
    public class VentesViewModel : ViewModelBase
    {

        public VentesViewModel()
        {
            GetProductsAll();
        }

        public ObservableCollection<VentePdtItemViewModel> ListeProduits { get; set; } = new ObservableCollection<VentePdtItemViewModel>();
        public ObservableCollection<DetailMouvementStockDTO> Panier { get; set; } = new ObservableCollection<DetailMouvementStockDTO>();

        public Visibility _isPopUpVisible = Visibility.Collapsed;

        public Visibility IsPopUpVisible
        {
            get { return _isPopUpVisible; }
            set
            {
                _isPopUpVisible = value;
                OnPropertyChanged(nameof(IsPopUpVisible));

            }
        }


        private ProduitLightDTO _currentProduitDTO;
        public ProduitLightDTO CurrentProduitDTO
        {
            get { return _currentProduitDTO; }
            set
            {
                _currentProduitDTO = value;
                OnPropertyChanged(nameof(CurrentProduitDTO));
            }
        }

        private void GetProductsAll()
        {
            ListeProduits.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetProduitsAll();

            })
            .ContinueWith(t =>
            {
                foreach (var produit in t.Result)
                {
                    var item = new VentePdtItemViewModel(produit);
                    item.EH_ajoutPanier += Item_ajoutPanier;
                    item.EH_plusU += Item_plusU;
                    item.EH_voirPdt += Item_voirPdt;
                    item.EH_plusU += Item_plusU;
                    item.EH_moinsU += Item_moinsU;
                    item.EH_plusC += Item_plusC;
                    item.EH_moinsC += Item_moinsC;
                    ListeProduits.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Item_ajoutPanier(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;

            if (item.QteUnite > 0)
            {
                DetailMouvementStockDTO lgnVente = new DetailMouvementStockDTO()
                {
                    ProduitId = item.ProduitLightDTO.Id,
                    QteProduit = item.QteUnite,
                    AuCarton = false,
                    SousTotal = item.ProduitLightDTO.PrixVente * item.QteUnite
                };
                Panier.Add(lgnVente);
            }
            if (item.QteCarton > 0)
            {
                DetailMouvementStockDTO lgnVente = new DetailMouvementStockDTO()
                {
                    ProduitId = item.ProduitLightDTO.Id,
                    QteProduit = item.QteCarton,
                    AuCarton = false,
                    SousTotal = item.ProduitLightDTO.PrixVenteCarton * item.QteUnite
                };
                Panier.Add(lgnVente);
            }
        }

        private void Item_voirPdt(object? sender, EventArgs e)
        {

        }
        private void Item_plusU(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteUnite++;
            OnPropertyChanged(nameof(item.QteUnite));
        }
        private void Item_moinsU(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteUnite--;
            if (item.QteUnite < 0) item.QteUnite = 0;
            OnPropertyChanged(nameof(item.QteUnite));
        }
        private void Item_plusC(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteCarton++;
            OnPropertyChanged(nameof(item.QteCarton));
        }
        private void Item_moinsC(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteCarton--;
            if (item.QteCarton < 0) item.QteCarton = 0;

            OnPropertyChanged(nameof(item.QteCarton));
        }


    }
}
