using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
	public class Inventaire
	{
		public int Id { get; set; }
		public DateTime DateInventaire { get; set; }
		//public int NumInventaire { get; set; }
		public bool IsValidated { get; set; }

		public virtual ICollection<LigneInventaire>? LigneInventaires { get; set; }

	}
}
