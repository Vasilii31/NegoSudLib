using NegoSudLib.DAO;
namespace NegoSudLib.DTO.Read;

// Produit entier avec historique achats
public class ProduitFullDTO

{
    public int Id { get; set; }
    public string NomProduit { get; set; } = string.Empty;
    public int ContenanceCl { get; set; }
    public int QteEnStock { get; set; }
    public int CommandeMin { get; set; }
    public int SeuilCommandeMin { get; set; }
    public float DegreeAlcool { get; set; }
    public int Millesime { get; set; }
    public int QteCarton { get; set; }
    public string PhotoProduitPath { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string NomDomaine { get; set; } = string.Empty;
    public string NomCategorie { get; set; } = string.Empty;
    public ICollection<PrixVente> HistoriquePrixVentes { get; set; } = [];
    public ICollection<PrixAchat> HistoriquePrixAchats { get; set; } = [];
}
