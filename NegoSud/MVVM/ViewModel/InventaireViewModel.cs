using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DAO;

using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class InventaireViewModel : ViewModelBase
    {
        public ObservableCollection<ItemInventaireViewModel> ListeProduits { get; set; } = new();
        public ObservableCollection<TypeMouvement> ListeTypesMouvements { get; set; } = new();
        public ObservableCollection<ItemInventaireViewModel> ListeMouvements { get; set; } = new();
        public ICommand ValiderMvTCommand { get; set; }
        public ICommand OpenFormValidationCommand { get; set; }
        public ICommand OpenFormAddTypeMouvementCommand { get; set; }
        public ICommand CancelFormAddTypeMouvementCommand { get; set; }
        public ICommand CreerTypeMvtCommand { get; set; }

    private TypeMouvement typeMouvementSelectionne;
        public TypeMouvement TypeMouvementSelectionne
        {
            get { return typeMouvementSelectionne; }
            set
            {
                if (typeMouvementSelectionne != value)
                {
                    typeMouvementSelectionne = value;
                    OnPropertyChanged(nameof(TypeMouvement));
                }
            }
        }
        public ICommand CancelFormValidationCommand { get; set; }

        private Visibility _isFormValidationVisible = Visibility.Hidden;
        public Visibility IsFormValidationVisible
        {
            get { return _isFormValidationVisible; }
            set
            {
                _isFormValidationVisible = value;
                OnPropertyChanged(nameof(IsFormValidationVisible));
            }
        }

        private Visibility _isFormAddTypeMouvementVisible = Visibility.Hidden;
        public Visibility IsFormAddTypeMouvementVisible
        {
            get { return _isFormAddTypeMouvementVisible; }
            set
            {
                _isFormAddTypeMouvementVisible = value;
                OnPropertyChanged(nameof(IsFormAddTypeMouvementVisible));
            }
        }


        private string _commentaire = "";
        public string Commentaire
        {
            get { return _commentaire; }
            set
            {
                _commentaire = value;
                OnPropertyChanged(nameof(Commentaire));
            }
        }

        private string _nomNewTypeMvt = "";
        public string NomNewTypeMvt
        {
            get { return _nomNewTypeMvt; }
            set
            {
                _nomNewTypeMvt = value;
                OnPropertyChanged(nameof(NomNewTypeMvt));
            }
        }

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
            ValiderMvTCommand = new RelayCommand(Post_Command);
            OpenFormValidationCommand = new RelayCommand(OpenForm);
            CancelFormValidationCommand = new RelayCommand(CancelForm);
            OpenFormAddTypeMouvementCommand = new RelayCommand(OpenAddTypeMouvementForm);
            CancelFormAddTypeMouvementCommand = new RelayCommand(CloseAddTypeMouvementForm);
            CreerTypeMvtCommand = new RelayCommand(CreateNewTypeMvt);
        }

        private void CreateNewTypeMvt(object obj)
        {
            if(NomNewTypeMvt == "")
            {
                MessageBox.Show("Veuillez entrer un nom de type de mouvement.");
                return;
            }

            TypeMouvement typeMouvement = new TypeMouvement()
            {
                NomTypeMouvement = NomNewTypeMvt,
            };

            Task.Run(async () =>
            {
                return await httpClientService.AddTypeMouvement(typeMouvement);

            })
            .ContinueWith(t =>
            {
                if (t.Result == null)
                {
                    MessageBox.Show("Une erreur est survenue.");
                }
                else
                {
                    MessageBox.Show("Type Mouvement enregistré avec succès.");
                    GetTypesMouvementsAll();
                    NomNewTypeMvt = "";
                    IsFormAddTypeMouvementVisible = Visibility.Hidden;
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void CloseAddTypeMouvementForm(object obj)
        {
            NomNewTypeMvt = "";
            IsFormAddTypeMouvementVisible = Visibility.Hidden;
        }

        private void OpenAddTypeMouvementForm(object obj)
        {
            
            IsFormAddTypeMouvementVisible = Visibility.Visible;
        }

        private void CancelForm(object obj)
        {
            Commentaire = "";
            TypeMouvementSelectionne = null;
            IsFormValidationVisible = Visibility.Hidden;
        }

        private void OpenForm(object obj)
        {
            if (ListeMouvements.Count() == 0)
                return;
            if (IsFormValidationVisible == Visibility.Hidden)
            {
                IsFormValidationVisible = Visibility.Visible;
            }

        }

        private void Post_Command(object obj)
        {
            if (IsFormValidationVisible != Visibility.Visible)
                return;
            //On créé le Autre mouvement qui va contenir tout les details de 
            //mouvement de stock
            if(typeMouvementSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un type de mouvement.");
                return;
            }
            
            AutreMvtWriteDTO mvt = new AutreMvtWriteDTO()
            {
                DateMouvement = DateTime.Now,
                Commentaire = Commentaire,
                //Gestion entreeSortie a implémenter
                EntreeOuSortie = true,
                EmployeId = Int32.Parse(App.Current.Properties["EmployeID"].ToString()),
                TypeMouvementId = TypeMouvementSelectionne.Id,
                DetailMouvementStocks = new List<DetailMouvementStock>()

            };

            foreach (ItemInventaireViewModel item in ListeMouvements)
            {
                var details = new DetailMouvementStock
                {
                    QteProduit = item.QteChangementStock,
                    PrixApresRistourne = 0.0f,
                    AuCarton = false,
                    // a verifier ? comment recuperer le idmouvementStock
                    MouvementStockId = 1,
                    ProduitId = item.ProduitLightDTO.Id
                };
                mvt.DetailMouvementStocks.Add(details);
            }

            //MessageBox.Show(mvt.Commentaire

            Task.Run(async () =>
            {
                return await httpClientService.AddMouvementStock(mvt);

            })
            .ContinueWith(t =>
            {
                if(t.Result == null)
                {
                    MessageBox.Show("Une erreur est survenue.");
                }
                else
                {
                    MessageBox.Show("Mouvement enregistré avec succès.");
                    ListeMouvements.Clear();
                    TypeMouvementSelectionne = null;
                    Commentaire = "";
                    IsFormValidationVisible = Visibility.Hidden;
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
            

            //A la fin, on nettoie la liste
            //ListeMouvements.Clear();
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
                    var item = new ItemInventaireViewModel(produit);
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
            if (IsFormValidationVisible == Visibility.Visible)
                return;
            ItemInventaireViewModel item = (ItemInventaireViewModel)sender;
            item.QteChangementStock++;
        }
        private void Item_MoinsU(object? sender, EventArgs e)
        {
            if (IsFormValidationVisible == Visibility.Visible)
                return;
            ItemInventaireViewModel item = (ItemInventaireViewModel)sender;
            item.QteChangementStock--;
            //if (item.QteUnite < 0) item.QteUnite = 0;
        }


        private void Item_AjoutPanier(object? sender, EventArgs e)
        {
            if (IsFormValidationVisible == Visibility.Visible)
                return;
            ItemInventaireViewModel item = (ItemInventaireViewModel)sender;
            //Si le compteur est à 0 ou qu'on a pas sélectionné de type mouvement, 
            // On ne fait rien
            if (item.QteChangementStock == 0)
                return;

            // on créé un nouvel item qu'on subscribe a l'event delete
            ItemInventaireViewModel mvt = new ItemInventaireViewModel(item);
            mvt.EH_Delete += Item_Remove;
            // On ajoute l'item à la liste
            ListeMouvements.Add(mvt);
            // Et on réinitialise l'item pour le tableau du haut
            item.ResetItem();



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

        private void Item_Remove(object? sender, EventArgs e)
        {
            if (IsFormValidationVisible == Visibility.Visible)
                return;
            ItemInventaireViewModel item = (ItemInventaireViewModel)sender;
            if (item != null)
                ListeMouvements.Remove(item);
        }
    }
}
