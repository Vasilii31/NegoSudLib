using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class EmployeItemViewModel : ViewModelBase
    {
        public EmployeDTO EmployeDTO { get;  }
        public string NomPrenom { get; set; }
        public string Role {  get; set; }

        public ICommand ClickDeleteCommand { get; set; }

        public ICommand ClickModifyCommand { get; set; }

        public event EventHandler deleted;
        public event EventHandler modify;

        public EmployeItemViewModel(EmployeDTO employe)
        {
            EmployeDTO = employe;
            NomPrenom = employe.NomUtilisateur + " " + employe.PrenomUtilisateur;
            Role = employe.Gerant ? "Gérant" : "Employé";
            ClickDeleteCommand = new RelayCommand(ClickDelete);
            ClickModifyCommand = new RelayCommand(ClickModify);
        }


        private void ClickDelete(object obk)
        {
            MessageBoxResult answer = MessageBox.Show("Etes vous sûr de vouloir supprimer cet employé ?", "Suppression d'un employé", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (answer == MessageBoxResult.Yes)
            {
                
                Task.Run(async () =>
                {
                    return await httpClientService.DeleteEmploye(EmployeDTO.Id);

                }).ContinueWith(t =>
                {
                    if (t.Result == true)
                    {
                        deleted?.Invoke(this, EventArgs.Empty);
                        MessageBox.Show("L'employé a été supprimé avec succès.");
                    }
                    else
                        MessageBox.Show("Suppression impossible.");

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
                return;
        }

        private void ClickModify(object obk)
        {
            modify.Invoke(this.EmployeDTO, EventArgs.Empty);
        }

    }
}
