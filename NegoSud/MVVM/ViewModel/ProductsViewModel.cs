using MySqlX.XDevAPI.Common;
using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DTO.Read;
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
        public int NombreProduit { get => ListeProduits.Count(); }

        public Visibility _isPopUpVisible = Visibility.Collapsed;
        public ICommand ValidateFormCommand { get; set; }
        public ICommand DeleteFormCommand { get; set; }
        public ICommand ExitFormCommand { get; set; }

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
            DeleteFormCommand = new RelayCommand(DeleteItem);
            ValidateFormCommand = new RelayCommand(ValidateForm);
            ExitFormCommand = new RelayCommand(ExitForm);
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
                    }
                    else
                        MessageBox.Show("Suppression impossible.");
                    ListeProduits.Remove(CurrentProduitDTO);
                    CurrentProduitDTO = null;
                    IsPopUpVisible = Visibility.Collapsed;

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

        private void ValidateForm(object obj)
        {
            var ob = CurrentProduitDTO;
            Task.Run(async () =>
            {
                return await httpClientService.GetEmployes();

            });
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
