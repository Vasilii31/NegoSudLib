using NegoSudLib.DTO.Read;

namespace NegoSudWeb.Models
{
	public class ProduitsViewModel
	{
		public ProduitsViewModel(ProduitLightDTO produit)
		{
			Produit = produit;
			infoCard = produit.ContenanceCl + "cl - " + produit.DegreeAlcool + " % vol";
			infoCardCarton = "Au carton (" + produit.QteCarton + ")";
			prixUnite = produit.PrixVente + " €";
			prixCarton = produit.PrixVenteCarton + " €";
			enStock = (produit.QteEnStock > 0) ? "En stock" : "A commander";
		}
		public ProduitLightDTO Produit { get; set; } = null!;
		public string infoCard { get; set; }
		public string infoCardCarton { get; set; }
		public string prixUnite { get; set; }
		public string prixCarton { get; set; }
		public int QteUnite { get; set; }
		public int QteCarton { get; set; }

		public string enStock { get; set; }

	}
}
