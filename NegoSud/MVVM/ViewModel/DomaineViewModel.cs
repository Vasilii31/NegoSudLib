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

    public class DomaineViewModel : ViewModelBase
    {
        private DomaineLightViewModel _selectedDomaine;
        public ObservableCollection<DomaineLightViewModel> ListeDomaine { get; set; } = new();

        public int NombreListeDomaine { get => ListeDomaine.Count(); }

        public DomaineLightViewModel SelectedDomaine
        {
            get { return _selectedDomaine; }
            set
            {
                if (_selectedDomaine != value)
                {
                    _selectedDomaine = value;
                    OnPropertyChanged(nameof(SelectedDomaine));
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

        public ICommand DeleteSelectedCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand ExitFormCommand { get; set; }
        public ICommand ValidateFormCommand { get; set; }
        public ICommand ModifyCommand { get; set; }

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

        

        private DomaineLightViewModel _currentDomaineDTO;

        public DomaineLightViewModel CurrentDomaineDTO
        {
            get { return _currentDomaineDTO; }
            set
            {
                _currentDomaineDTO = value;
                OnPropertyChanged(nameof(CurrentDomaineDTO));
            }
        }

        public DomaineViewModel()
        {
            GetDomaine();
            DeleteSelectedCommand = new RelayCommand(DeleteSelected, CanDeleteSelected);
            CreateCommand = new RelayCommand(CreateDomaine);
            ValidateFormCommand = new RelayCommand(ValidateForm);
            ExitFormCommand = new RelayCommand(ExitForm);
            ModifyCommand = new RelayCommand(ModifyDomaine);
        }

        private async void ValidateForm(object obj)
        {
          var ob = CurrentDomaineDTO;
            if (modify)
            {
                await httpClientService.UpdateDomaine(ob.Domaine);
            }
            else
            {
                await httpClientService.CreateDomaine(ob.Domaine);
            }
            GetDomaine();
            IsPopUpVisible = Visibility.Collapsed;  
        }

        private void ExitForm(object obj)
        {
            CurrentDomaineDTO = null;
            IsPopUpVisible = Visibility.Collapsed;
        }


        private bool CanDeleteSelected(object parameter)
        {
            return SelectedDomaine != null;
        }

        private void DeleteSelected(object obj)
        {
           Task.Run(async () =>
           {
                return await httpClientService.DeleteDomaine(SelectedDomaine.Domaine.Id);
            }).ContinueWith(t =>
            {
                if (t.Result)
                {
                    ListeDomaine.Remove(SelectedDomaine);
                    OnPropertyChanged(nameof(NombreListeDomaine));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void GetDomaine()
        {
            ListeDomaine.Clear();
            Task.Run(async () =>
            {
                return await httpClientService.GetDomainess();


            }).ContinueWith(t =>
            {
                foreach (var domaine in t.Result)
                {
                    var domaineViewModel = new DomaineLightViewModel(domaine);
                    
                    ListeDomaine.Add(new DomaineLightViewModel(domaine));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CreateDomaine(object obj)
        {
            IsPopUpVisible = Visibility.Visible;
            CurrentDomaineDTO = new DomaineLightViewModel(new DomaineDTO());
            IsDeleteButtonVisible = Visibility.Hidden;
            modify = false;
        }

        private void ModifyDomaine(object obj)
        {
            if (IsPopUpVisible == Visibility.Collapsed)
            {
                IsPopUpVisible = Visibility.Visible;

                if (SelectedDomaine != null)
                {
                    // Modification
                    CurrentDomaineDTO = new DomaineLightViewModel(new DomaineDTO
                    {
                        Id = SelectedDomaine.Domaine.Id,
                        NomDomaine = SelectedDomaine.Domaine.NomDomaine
                    });

                    modify = true;
                    IsDeleteButtonVisible = Visibility.Visible;
                }
            }

        }
    }
 
}
