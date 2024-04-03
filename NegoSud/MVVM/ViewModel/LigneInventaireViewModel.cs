using NegoSudLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
	public class LigneInventaireViewModel : ViewModelBase
	{
        public LigneInventaire Ligne { get; set; }

        public int SoldeMouvement { get; set; }

        public LigneInventaireViewModel(LigneInventaire li)
        {
            Ligne = li;
            SoldeMouvement = Ligne.QuantiteApresInventaire - Ligne.QuantiteAvantInventaire;
        }
    }
}
