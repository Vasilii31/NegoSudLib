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

        public FournisseurDetailDTO CurrentFournisseurDTO
        {
            get { return _currentFournisseurDTO; }
            set
            {
                _currentFournisseurDTO = value;
                OnPropertyChanged(nameof(CurrentFournisseurDTO));
            }
        }

        private bool _isAjoutFournisseurVisible;

        public bool IsAjoutFournisseurVisible
        {
            get { return _isAjoutFournisseurVisible; }
            set
            {
                _isAjoutFournisseurVisible = value;
                OnPropertyChanged(nameof(IsAjoutFournisseurVisible));
            }
        }

        public ICommand DeleteSelectedCommand { get; private set; }

        public ICommand CreateFournisseurCommand { get; private set; }

        private bool modify = false;


        public FournisseurViewModel()
        {
            CurrentFournisseurDTO = new FournisseurDetailDTO();
            GetFournisseur();
            DeleteSelectedCommand = new RelayCommand(DeleteSelected, CanDeleteSelected);
            CreateFournisseurCommand = new RelayCommand(CreateFournisseur);
        }

        private void CreateFournisseur(object obj)
        {
            IsAjoutFournisseurVisible = true;

            if (CurrentFournisseurDTO == null)
            {
                CurrentFournisseurDTO = new FournisseurDetailDTO();
            }

            FournisseurDetailDTO newFournisseur = new FournisseurDetailDTO
            {
                NomFournisseur = CurrentFournisseurDTO.NomFournisseur,
                AdresseFournisseur = CurrentFournisseurDTO.AdresseFournisseur,
                NumTelFournisseur = CurrentFournisseurDTO.NumTelFournisseur,
                EmailFournisseur = CurrentFournisseurDTO.EmailFournisseur
            };

            Task.Run(async () =>
            {
                var isSuccess = await httpClientService.PostFournisseur(newFournisseur);

                if (isSuccess)
                {
                    ListeFournisseur.Add(new FournisseurLightViewModel(newFournisseur));
                    OnPropertyChanged(nameof(NombreListeFournisseur));
                    MessageBox.Show("Fournisseur créé avec succès.");
                }
                else
                {
                    MessageBox.Show("La création du fournisseur a échoué.");
                }
            });
        }

        private bool CanDeleteSelected(object obj)
        {
            return SelectedFournisseur != null;
        }

        private void DeleteSelected(object obj)
        {
            if (SelectedFournisseur != null)
            {
                ListeFournisseur.Remove(SelectedFournisseur);
                OnPropertyChanged(nameof(NombreListeFournisseur));
            }
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
                    ListeFournisseur.Add(new FournisseurLightViewModel(fournisseur));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
  
}
