using NegoSud.Services;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
    public class EmployesViewModel : ViewModelBase
    {
        public ObservableCollection<EmployeItemViewModel> ListeEmployes { get; set; } = new();
        public int NombreEmployes { get => ListeEmployes.Count(); }

        public EmployesViewModel() {
            GetEmployes();
        }

        public void GetEmployes()
        {
            ListeEmployes.Clear();
            OnPropertyChanged(nameof(NombreEmployes));

            Task.Run(async () =>
            {
                return await httpClientService.GetEmployes();

            })
            .ContinueWith(t =>
            {
                //ListeEmployes = t.Result;
                foreach (var employe in t.Result)
                {
                    ListeEmployes.Add(new EmployeItemViewModel(employe));
                }

                //OnPropertyChanged(nameof(NombreListeVols));

            }, TaskScheduler.FromCurrentSynchronizationContext());


        }
    }
}
