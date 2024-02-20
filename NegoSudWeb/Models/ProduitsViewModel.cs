using NegoSudLib.DTO.Read;

namespace NegoSudWeb.Models
{
    public class ProduitsViewModel
    {
        public ProduitsViewModel(ProduitLightDTO produit)
        {
            Produit = produit;
            infoCard = produit.ContenanceCl + "cl - " + produit.DegreeAlcool + " % vol";
            infoCarton = "Au carton (" + produit.QteCarton + ")";
            prixUnite = produit.PrixVente + " €";
            prixCarton = produit.PrixVenteCarton + " €";
        }
        public ProduitLightDTO Produit { get; set; } = null!;
        public string infoCard { get; set; }
        public string infoCarton { get; set; }
        public string prixUnite { get; set; }
        public string prixCarton { get; set; }
        public int QteUnite { get; set; }
        public int QteCarton { get; set; }
    }
}
