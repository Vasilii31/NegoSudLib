using NegoSud.Services;
using NegoSudLib.DAO;
using System.Collections.ObjectModel;
using System.Windows;

namespace NegoSud.MVVM.ViewModel
{
    public class InventaireViewModel : ViewModelBase
    {
        public ObservableCollection<ItemInventaireViewModel> ListeProduits { get; set; } = new();
        public ObservableCollection<TypeMouvement> ListeTypesMouvements { get; set; } = new();

        private string _recherche;

        public string Recherche
        {
            get { return _recherche; }
            set
            {
                if (value != _recherche)
                {
                    _recherche = value;
                    OnPropertyChanged(nameof(Recherche));
                }
            }
        }

        public InventaireViewModel()
        {
            GetProductsAll();
            GetTypesMouvementsAll();
        }

        private void GetTypesMouvementsAll()
        {
            ListeTypesMouvements.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetTypesMouvementsAll();

            })
            .ContinueWith(t =>
            {
                foreach (var typeMouvement in t.Result)
                {
                    ListeTypesMouvements.Add(typeMouvement);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
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
                    var item = new ItemInventaireViewModel(produit, ListeTypesMouvements);
                    item.EH_AjoutPanier += Item_AjoutPanier;
                    //item.EH_VoirPdt += Item_VoirPdt;
                    item.EH_PlusU += Item_PlusU;
                    item.EH_MoinsU += Item_MoinsU;
                    //item.EH_PlusC += Item_PlusC;
                    //item.EH_MoinsC += Item_MoinsC;
                    ListeProduits.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        internal void SearchProduits(object sender, RoutedEventArgs e)
        {
            ListeProduits.Clear();
            Task.Run(async () =>
            {
                return await httpClientService.SearchProduits(0, 0, 0, Recherche, null);

            })
                        .ContinueWith(t =>
                        {
                            foreach (var produit in t.Result)
                            {
                                var item = new ItemInventaireViewModel(produit, ListeTypesMouvements);
                                item.EH_AjoutPanier += Item_AjoutPanier;
                                //item.EH_VoirPdt += Item_VoirPdt;
                                item.EH_PlusU += Item_PlusU;
                                item.EH_MoinsU += Item_MoinsU;
                                //item.EH_PlusC += Item_PlusC;
                                //item.EH_MoinsC += Item_MoinsC;
                                ListeProduits.Add(item);

                            }

                        }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        // Methodes pour les boutons dans la liste
        private void Item_PlusU(object? sender, EventArgs e)
        {
            MessageBox.Show(App.Current.Properties["EmployeID"].ToString());
            ItemInventaireViewModel item = (ItemInventaireViewModel)sender;
            item.QteChangementStock++;
        }
        private void Item_MoinsU(object? sender, EventArgs e)
        {
            ItemInventaireViewModel item = (ItemInventaireViewModel)sender;
            item.QteChangementStock--;
            //if (item.QteUnite < 0) item.QteUnite = 0;
        }

        private void Item_AjoutPanier(object? sender, EventArgs e)
        {


            //VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            //if (item.QteUnite > 0)
            //{
            //    DetailMouvementStockDTO dtMvt = new DetailMouvementStockDTO()
            //    {
            //        ProduitId = item.ProduitLightDTO.Id,
            //        Produit = item.ProduitLightDTO,
            //        QteProduit = item.QteUnite,
            //        PrixApresRistourne = -1,
            //        AuCarton = false,
            //        SousTotal = item.ProduitLightDTO.PrixVente * item.QteUnite
            //    };

            //    AjouterOuModifierDansPanier(dtMvt);
            //}
            //if (item.QteCarton > 0)
            //{
            //    DetailMouvementStockDTO dtMvt = new DetailMouvementStockDTO()
            //    {
            //        ProduitId = item.ProduitLightDTO.Id,
            //        Produit = item.ProduitLightDTO,
            //        QteProduit = item.QteCarton,
            //        PrixApresRistourne = -1,
            //        AuCarton = true,
            //        SousTotal = item.ProduitLightDTO.PrixVenteCarton * item.QteCarton
            //    };
            //    AjouterOuModifierDansPanier(dtMvt);
            //}
            //item.AjoutVisible = Visibility.Visible;
            //Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t => item.AjoutVisible = Visibility.Collapsed, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
