using MySqlX.XDevAPI.Common;
using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<ProductsItemViewModel> ListeProduits { get; set; } = new();
        public ObservableCollection<CategorieDTO> ListeCategories { get; set; } = new();

        public ObservableCollection<Domaine> ListeDomaines { get; set; } = new();
        public int NombreProduit { get => ListeProduits.Count(); }

       
        public ICommand ValidateFormCommand { get; set; }
        public ICommand DeleteFormCommand { get; set; }
        public ICommand ExitFormCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        private bool modify = false;

        private CategorieDTO _categorieSelectionnee;
        public CategorieDTO CategorieSelectionnee
        {
            get { return _categorieSelectionnee; }
            set
            {
                _categorieSelectionnee = value;
                OnPropertyChanged(nameof(CategorieSelectionnee));
            }
        }

        private Domaine _domaineSelectionne;
        public Domaine DomaineSelectionne
        {
            get { return _domaineSelectionne; }
            set
            {
                _domaineSelectionne = value;
                OnPropertyChanged(nameof(DomaineSelectionne));
            }
        }

        public Visibility _isDeleteButtonVisible = Visibility.Visible;
        public Visibility IsDeleteButtonVisible
        {
            get { return _isDeleteButtonVisible; }
            set
            {
                _isDeleteButtonVisible = value;
                OnPropertyChanged(nameof(IsDeleteButtonVisible));

            }
        }

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

        private ProductsItemViewModel _currentProduitDTO;
        public ProductsItemViewModel CurrentProduitDTO
        {
            get { return _currentProduitDTO; }
            set
            {
                _currentProduitDTO = value;
                OnPropertyChanged(nameof(CurrentProduitDTO));
            }
        }

        public ProductsViewModel()
        {
            GetProductsAll();
            GetCategories();
            GetDomaines();
            DeleteFormCommand = new RelayCommand(DeleteItem);
            ValidateFormCommand = new RelayCommand(ValidateForm);
            ExitFormCommand = new RelayCommand(ExitForm);
            CreateCommand = new RelayCommand(CreateProduit);
        }

        private void CreateProduit(object obj)
        {
            IsPopUpVisible = Visibility.Visible;
            CurrentProduitDTO = new ProductsItemViewModel(new ProduitLightDTO());
            IsDeleteButtonVisible = Visibility.Hidden;
            modify = false;
        }

        private void GetCategories()
        {
            ListeCategories.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetCategories();

            })
            .ContinueWith(t =>
            {
                foreach (var categorie in t.Result)
                {

                    ListeCategories.Add(categorie);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void GetDomaines()
        {
            ListeDomaines.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetDomaines();

            })
            .ContinueWith(t =>
            {
                foreach (var domaine in t.Result)
                {

                    ListeDomaines.Add(domaine);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void DeleteItem(object obj)
        {
            MessageBoxResult answer = MessageBox.Show("Etes vous sûr de vouloir supprimer ce produit ? Cette suppression sera définitive.", "Suppression d'un produit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                //ProductsItemViewModel item = (ProductsItemViewModel)obj;
                Task.Run(async () =>
                {
                    return await httpClientService.DeleteProduit(CurrentProduitDTO.ProduitLightDTO.Id);

                }).ContinueWith(t =>
                {
                    if (t.Result == true)
                    {
                        MessageBox.Show("Le produit a été supprimé avec succès.");
                        ListeProduits.Remove(CurrentProduitDTO);
                        CurrentProduitDTO = null;
                        IsPopUpVisible = Visibility.Collapsed;
                    }
                    else
                        MessageBox.Show("Suppression impossible.");
                    

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
                return;
        }


        private void ExitForm(object obj)
        {
            CurrentProduitDTO = null;
            IsPopUpVisible = Visibility.Collapsed;
        }

        private async void ValidateForm(object obj)
        {
            var ob = CurrentProduitDTO;
            if (modify == false)
            {
                MessageBox.Show("ajout");
                ProduitWriteDTO produitWriteDTO = new ProduitWriteDTO()
                {
                    Id = CurrentProduitDTO.ProduitLightDTO.Id,
                    NomProduit = CurrentProduitDTO.ProduitLightDTO.NomProduit,
                    ContenanceCl = CurrentProduitDTO.ProduitLightDTO.ContenanceCl,
                    QteEnStock = CurrentProduitDTO.ProduitLightDTO.QteEnStock,
                    DegreeAlcool = CurrentProduitDTO.ProduitLightDTO.DegreeAlcool,
                    PhotoProduitPath = CurrentProduitDTO.ProduitLightDTO.PhotoProduitPath,
                    DescriptionProduit = "",//CurrentProduitDTO.ProduitLightDTO
                    SeuilCommandeMin = CurrentProduitDTO.ProduitLightDTO.SeuilCommandeMin,
                    CommandeMin = CurrentProduitDTO.ProduitLightDTO.CommandeMin,
                    IdDomaine = 1, // a gerer apres
                    IdCategorie = 1, // A gerer aussi
                    AlaVente = CurrentProduitDTO.ProduitLightDTO.ALaVente,
                    PrixAchat = new PrixAchat()
                    {
                        ProduitId = CurrentProduitDTO.ProduitLightDTO.Id,
                        PrixUnite = CurrentProduitDTO.ProduitLightDTO.PrixAchat,
                        PrixCarton = CurrentProduitDTO.ProduitLightDTO.PrixAchatCarton
                    },
                    PrixVente = new PrixVente()
                    {
                        PrixUnite = CurrentProduitDTO.ProduitLightDTO.PrixVente,
                        PrixCarton = CurrentProduitDTO.ProduitLightDTO.PrixVenteCarton
                    }
                };
                Task.Run(async () =>
                        {
                            //return await httpClientService.GetEmployes();
                            //return await httpClientService.ModifyProduct(produitWriteDTO, CurrentProduitDTO.ProduitLightDTO.Id);
                            return await httpClientService.CreateNewProduct(produitWriteDTO);

                        }).ContinueWith(t =>
                        {
                            //if (t.Result.Id == 0)
                            //{
                            //    MessageBox.Show("Modification impossible.");
                            //}
                            //else
                            MessageBox.Show("Produit créé");
                            //ListeProduits.Remove(CurrentProduitDTO);
                            //CurrentProduitDTO = null;
                            //IsPopUpVisible = Visibility.Collapsed;

                        }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {

                MessageBox.Show("Modifier");
                //ProduitWriteDTO produitWriteDTO;
                //ProduitFullDTO? test = null;
                ////Verification des infos : on verra plus tard
                //Task.Run(async () =>
                //{
                //    //return await httpClientService.GetEmployes();
                //    test = await httpClientService.GetProductById(ob.ProduitLightDTO.Id);

                //}).ContinueWith(t =>
                //{
                //    produitWriteDTO = new ProduitWriteDTO()
                //    {
                //        Id = test.Id,
                //        NomProduit = CurrentProduitDTO.ProduitLightDTO.NomProduit,
                //        ContenanceCl = test.ContenanceCl,
                //        QteEnStock = test.QteEnStock,
                //        DegreeAlcool = test.DegreeAlcool,
                //        PhotoProduitPath = test.PhotoProduitPath,
                //        DescriptionProduit = "",//CurrentProduitDTO.ProduitLightDTO
                //        SeuilCommandeMin = test.SeuilCommandeMin,
                //        CommandeMin = test.CommandeMin,
                //        IdDomaine = 1, // a gerer apres
                //        IdCategorie = 1, // A gerer aussi
                //        AlaVente = CurrentProduitDTO.ProduitLightDTO.ALaVente,
                //        PrixAchat = test.HistoriquePrixAchats.First(),
                //        PrixVente = test.HistoriquePrixVentes.First()
                //    };
                //});
                //on instancie produitWrite Dto
                //ProduitWriteDTO produitWriteDTO = new ProduitWriteDTO()
                //{
                //    Id = CurrentProduitDTO.ProduitLightDTO.Id,
                //    NomProduit = CurrentProduitDTO.ProduitLightDTO.NomProduit,
                //    ContenanceCl = CurrentProduitDTO.ProduitLightDTO.ContenanceCl,
                //    QteEnStock = CurrentProduitDTO.ProduitLightDTO.QteEnStock,
                //    DegreeAlcool = CurrentProduitDTO.ProduitLightDTO.DegreeAlcool,
                //    PhotoProduitPath = CurrentProduitDTO.ProduitLightDTO.PhotoProduitPath,
                //    DescriptionProduit = "",//CurrentProduitDTO.ProduitLightDTO
                //    SeuilCommandeMin = CurrentProduitDTO.ProduitLightDTO.SeuilCommandeMin,
                //    CommandeMin = CurrentProduitDTO.ProduitLightDTO.CommandeMin,
                //    IdDomaine = 1, // a gerer apres
                //    IdCategorie = 1, // A gerer aussi
                //    AlaVente = CurrentProduitDTO.ProduitLightDTO.ALaVente,
                //    PrixAchat = new PrixAchat()
                //    {
                //        ProduitId = CurrentProduitDTO.ProduitLightDTO.Id,
                //        PrixUnite = CurrentProduitDTO.ProduitLightDTO.PrixAchat,
                //        PrixCarton = CurrentProduitDTO.ProduitLightDTO.PrixAchatCarton
                //    },
                //    PrixVente = new PrixVente()
                //    {
                //        PrixUnite = CurrentProduitDTO.ProduitLightDTO.PrixVente,
                //        PrixCarton = CurrentProduitDTO.ProduitLightDTO.PrixVenteCarton
                //    }
                //};
                //Task.Run(async () =>
                //        {
                //            //return await httpClientService.GetEmployes();
                //            return await httpClientService.ModifyProduct(produitWriteDTO, CurrentProduitDTO.ProduitLightDTO.Id);

                //        }).ContinueWith(t =>
                //        {
                //            if (t.Result.Id == 0)
                //            {
                //                MessageBox.Show("Modification impossible.");
                //            }
                //            //else

                //            //ListeProduits.Remove(CurrentProduitDTO);
                //            //CurrentProduitDTO = null;
                //            //IsPopUpVisible = Visibility.Collapsed;

                //        }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            return;
        }

        private void Item_modifyPopup(object? sender, EventArgs e)
        {
            if (IsPopUpVisible == Visibility.Collapsed)
            {
                IsPopUpVisible = Visibility.Visible;
                if (sender != null)
                {
                    CurrentProduitDTO = (ProductsItemViewModel)sender;
                    IsDeleteButtonVisible = Visibility.Visible;
                    modify = true;
                }

            }
        }

        private void GetProductsAll()
        {
            ListeProduits.Clear();
            OnPropertyChanged(nameof(NombreProduit));

            Task.Run(async () =>
            {
                return await httpClientService.GetProduitsAll();

            })
            .ContinueWith(t =>
            {
                foreach (var produit in t.Result)
                {
                    var item = new ProductsItemViewModel(produit);
                    item.deleted += Item_deleted;
                    item.modify += Item_modifyPopup;
                    ListeProduits.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }




        private void Item_deleted(object? sender, EventArgs e)
        {
            ProductsItemViewModel item = (ProductsItemViewModel)sender;
            ListeProduits.Remove(item);
        }
    }
}
