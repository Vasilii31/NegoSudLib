using NegoSudLib.DAO;
using NegoSudLib.Migrations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
	public class ItemInventaireHistoriqueDetailsViewModel : ViewModelBase
	{

		public Inventaire Inventaire { get; set; }

		public ObservableCollection<LigneInventaireViewModel> ListeLigneInventaire { get; set; } = new();

        private string _inventaireDuDate;
		public string InventaireDuDate
		{
			get { return _inventaireDuDate; }
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
			set
			{
				_dateAffichee = value;
				OnPropertyChanged(nameof(DateAffichee));
			}
		}

		public ItemInventaireHistoriqueDetailsViewModel(Inventaire inv)
        {
			Inventaire = inv;
			DateAffichee = Inventaire.DateInventaire.Day.ToString() + '/' + Inventaire.DateInventaire.Month.ToString() + '/' + Inventaire.DateInventaire.Year.ToString();
			InventaireDuDate = "Inventaire du " + DateAffichee;
			foreach(var l in Inventaire.LigneInventaires)
			{
				ListeLigneInventaire.Add(new LigneInventaireViewModel(l));
			}
		}
    }
}
