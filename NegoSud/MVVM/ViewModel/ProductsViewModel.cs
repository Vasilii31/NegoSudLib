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
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<ProductsItemViewModel> ListeProduits { get; set; } = new();
        public int NombreProduit { get => ListeProduits.Count(); }

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

        public ProductsViewModel()
        {
            GetProductsAll();
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


        private void Item_modifyPopup(object? sender, EventArgs e)
        {
            if (IsPopUpVisible == Visibility.Collapsed)
            {
                IsPopUpVisible = Visibility.Visible;
                if (sender != null)
                {
                    CurrentProduitDTO = (ProduitLightDTO)sender;
                }

            }
        }

        private void Item_deleted(object? sender, EventArgs e)
        {
            ProductsItemViewModel item = (ProductsItemViewModel)sender;
            ListeProduits.Remove(item);
        }
    }
}
