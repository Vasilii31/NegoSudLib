using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class FournisseurViewModel : ViewModelBase
    {
        private FournisseurLightViewModel _selectedFournisseur;

        private FournisseurDetailDTO _currentFournisseurDTO;
        public ObservableCollection<FournisseurLightViewModel> ListeFournisseur { get; set; } = new();

        public int NombreListeFournisseur { get => ListeFournisseur.Count(); }

        public FournisseurLightViewModel SelectedFournisseur
        {
            get { return _selectedFournisseur; }
            set
            {
                if (_selectedFournisseur != value)
                {
                    _selectedFournisseur = value;
                    OnPropertyChanged(nameof(SelectedFournisseur));
                }
            }
        }

        private bool _isItemSelected;
        public bool IsItemSelected
        {
            get { return _isItemSelected; }
            set
            {
                _isItemSelected = value;
                OnPropertyChanged(nameof(IsItemSelected));
            }
        }

        public ICommand DeleteSelectedCommand { get; private set; }
        public ICommand CreateFournisseurCommand { get; private set; }
        public ICommand ModifyFournisseurCommand { get; private set; }
        public ICommand ExitFormCommand { get; private set; }
        public ICommand ValidateFormCommand { get; private set; }

        private bool modify = false;

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

        FournisseurLightViewModel _CurrentFournisseurDTO;

        public FournisseurLightViewModel CurrentFournisseurDTO
        {
            get { return _CurrentFournisseurDTO; }
            set
            {
                _CurrentFournisseurDTO = value;
                OnPropertyChanged(nameof(CurrentFournisseurDTO));
            }
        }

        public FournisseurViewModel()
        {
            GetFournisseur();
            DeleteSelectedCommand = new RelayCommand(DeleteSelected, CanDeleteSelected);
            CreateFournisseurCommand = new RelayCommand(CreateFournisseur);
            ModifyFournisseurCommand = new RelayCommand(ModifyFournisseur);
            ExitFormCommand = new RelayCommand(ExitForm);
            ValidateFormCommand = new RelayCommand(ValidateForm);
        }

        private void ExitForm(object obj)
        {
            CurrentFournisseurDTO = null;
            IsPopUpVisible = Visibility.Collapsed;
        }

        private async void ValidateForm(object obj)
        {
            var ob = CurrentFournisseurDTO;
            if (modify)
            { 
            await httpClientService.UpdateFournisseur(ob.Fournisseur);
            }
            else
            {
                await httpClientService.CreateFournisseur(ob.Fournisseur);
            }
            
            GetFournisseur();
            IsPopUpVisible = Visibility.Collapsed;
            
        }

        private void CreateFournisseur(object obj)
        {
            IsPopUpVisible = Visibility.Visible;
            CurrentFournisseurDTO = new FournisseurLightViewModel(new FournisseurDetailDTO());
            IsDeleteButtonVisible = Visibility.Hidden;
            modify = false;
        }

        private void ModifyFournisseur(object obj)
        {
            if (IsPopUpVisible == Visibility.Collapsed)
            {
                IsPopUpVisible = Visibility.Visible;

                if (SelectedFournisseur != null)
                {
                    // Modification
                    CurrentFournisseurDTO = new FournisseurLightViewModel(new FournisseurDetailDTO
                    {
                        Id = SelectedFournisseur.Fournisseur.Id,
                        NomFournisseur = SelectedFournisseur.Fournisseur.NomFournisseur,
                        AdresseFournisseur = SelectedFournisseur.Fournisseur.AdresseFournisseur,
                        NumTelFournisseur = SelectedFournisseur.Fournisseur.NumTelFournisseur,
                        EmailFournisseur = SelectedFournisseur.Fournisseur.EmailFournisseur


                    });

                    modify = true;
                    IsDeleteButtonVisible = Visibility.Visible;
                }
            }

        }

        private bool CanDeleteSelected(object obj)
        {
            return SelectedFournisseur != null;
        }

        private void DeleteSelected(object obj)
        {
            Task.Run(async () =>
            {
                return await httpClientService.DeleteFournisseur(SelectedFournisseur.Fournisseur.Id);
            }).ContinueWith(t =>
            {
                if (t.Result)
                {
                    ListeFournisseur.Remove(SelectedFournisseur);
                    OnPropertyChanged(nameof(NombreListeFournisseur));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void GetFournisseur() 
        {
            ListeFournisseur.Clear();
            Task.Run(async () =>
            {
                return await httpClientService.GetFournisseurss();


            }).ContinueWith(t =>
            {
                foreach (var fournisseur in t.Result)
                {
                    var fournisseurViewModel = new FournisseurLightViewModel(fournisseur);
                    ListeFournisseur.Add(new FournisseurLightViewModel(fournisseur));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
  
}
