using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DAO;
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
    public class CategoriesViewModel : ViewModelBase
    {
        public ObservableCollection<CategorieItemViewModel> ListeCategories { get; set; } = new();

        private CategorieItemViewModel _categorieSelected;

        public CategorieItemViewModel SelectedCategorie
        {
            get { return _categorieSelected; }
            set
            {
                _categorieSelected = value;
                OnPropertyChanged(nameof(SelectedCategorie));
            }
        }

        public bool create = true;

        public ICommand CreateCommand { get; set; }
        public ICommand ModifyCommand {  get; set; }

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

        public string _newCategorieName = "";
        public string NewCategorieName
        {
            get { return _newCategorieName; }
            set
            {
                _newCategorieName = value;
                OnPropertyChanged(nameof(NewCategorieName));

            }
        }


        public CategoriesViewModel()
        {
            GetCategories();
            
            CreateCommand = new RelayCommand(CreateCategorie);
            ModifyCommand = new RelayCommand(ModifyCategorie);
        }

        private void ModifyCategorie(object obj)
        {
            create = false;
            IsPopUpVisible = Visibility.Visible;
        }

        private void CreateCategorie(object obj)
        {
            create = true;
            IsPopUpVisible = Visibility.Visible;
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

                    ListeCategories.Add(new CategorieItemViewModel(categorie));

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        internal void ValiderCat(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void Retour(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
