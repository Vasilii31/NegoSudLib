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
    public class FournisseurViewModel : ViewModelBase
    {
        public ObservableCollection<FournisseurLightViewModel> ListeFournisseur { get; set; } = new();

        public int NombreListeFournisseur { get => ListeFournisseur.Count(); }

        public FournisseurViewModel()
        {
            GetFournisseur();
        }

        public void GetFournisseur() 
        {
            ListeFournisseur.Clear();
            Task.Run(async () =>
            {
                return await httpClientService.GetFournisseurs();


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
