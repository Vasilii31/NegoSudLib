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

        public ICommand DeleteSelectedCommand { get; }

        public DomaineViewModel()
        {
            GetDomaine();
            DeleteSelectedCommand = new RelayCommand(DeleteSelected, CanDeleteSelected);
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
                    ListeDomaine.Add(new DomaineLightViewModel(domaine));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
 
}
