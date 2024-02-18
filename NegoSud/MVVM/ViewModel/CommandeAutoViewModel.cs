using Microsoft.EntityFrameworkCore.Storage;
using NegoSud.Core;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.write;
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
    public class CommandeAutoViewModel : ViewModelBase
    {
        public CommandeWriteDTO CommandeToPush {  get; set; }
        public string DateCommande { get; set; }
        public string NomFournisseur { get; set; }

        private string _commentaireAAjouter = "";

        public ObservableCollection<CmdPdtItemViewModel> ListToOrder { get; set; } = new();


        public string CommentaireAAjouter
        {
            get { return _commentaireAAjouter; }
            set
            {
                _commentaireAAjouter = value;
                OnPropertyChanged(nameof(CommentaireAAjouter));

            }
        }

        private float _total = 0f;

        public float Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));

            }
        }


        public event EventHandler ouvrirCommandeForm;

        public ICommand ConsultCommandeAutoCommand { get; set; }

        public CommandeAutoViewModel(CommandeWriteDTO cmd) 
        { 
            CommandeToPush = cmd;
            DateCommande = cmd.DateMouvement.Day.ToString() + '/' + cmd.DateMouvement.Month.ToString() + '/' + cmd.DateMouvement.Year.ToString();
            ConsultCommandeAutoCommand = new RelayCommand(OuvrirConsultModifCommand);
        }

        public void RecalculateTotal()
        {
            Total = 0;
            foreach(var item in ListToOrder)
            {
                Total += item.SousTotal;
            }
        }

        private void OuvrirConsultModifCommand(object obj)
        {
            ouvrirCommandeForm?.Invoke(this, EventArgs.Empty);
        }

    }
}
