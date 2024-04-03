using Mysqlx.Crud;
using NegoSud.Core;
using NegoSudLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
	public class ItemInventaireHistoriqueViewModel : ViewModelBase
	{
		public Inventaire inventaire { get; set; }

		private string _inventaireDuDate;
		public string InventaireDuDate
		{
			get { return _inventaireDuDate;}
			set
			{
				_inventaireDuDate = value;
				OnPropertyChanged(nameof(InventaireDuDate));
			}
		}

        private string _dateAffichee;

        public string DateAffichee
        {
            get { return _dateAffichee; }
            set { 
                _dateAffichee = value;
                OnPropertyChanged(nameof(DateAffichee));
            }
        }

        private string _compteurProduitsInventories;
		public string CompteurProduitsInventories
		{
			get { return _compteurProduitsInventories; }
			set
			{
				_compteurProduitsInventories = value;
				OnPropertyChanged(nameof(CompteurProduitsInventories));
			}
		}

		public ICommand ConsultInventaireCommand { get; set; }

		public event EventHandler consult;

		public ItemInventaireHistoriqueViewModel(Inventaire inv)
        {
            inventaire = inv;
			//inventaire.DateInventaire = DateTime.Now;
			DateAffichee = inventaire.DateInventaire.Day.ToString() + '/' + inventaire.DateInventaire.Month.ToString() + '/' + inventaire.DateInventaire.Year.ToString();
			InventaireDuDate = "Inventaire du " + DateAffichee;
			if (inventaire.LigneInventaires != null)
				CompteurProduitsInventories = "Produits inventoriés : " + inventaire.LigneInventaires.Count().ToString();
			ConsultInventaireCommand = new RelayCommand(ConsulterInventaire);
			
		}

		private void ConsulterInventaire(object obj)
		{
			invoke_Consult(this);
		}

		protected void invoke_Consult(object sender)
		{
			consult?.Invoke(sender, EventArgs.Empty);
		}
	}
}
