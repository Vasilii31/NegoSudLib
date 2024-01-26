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

        public DomaineViewModel()
        {
            GetDomaine();
        }

        public void GetDomaine()
        {
            ListeDomaine.Clear();
            Task.Run(async () =>
            {
                return await httpClientService.GetDomaines();


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
