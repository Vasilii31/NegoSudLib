using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
	public class LigneInventaire
	{
		public int Id { get; set; }
		public int QuantiteAvantInventaire { get; set; }
		public int QuantiteApresInventaire { get; set; }

		public int InventaireId { get; set; }

		[ForeignKey(nameof(Produit))]
		public int IdProduit { get; set; }
		public virtual Produit? Produit { get; set; }
	}
}
