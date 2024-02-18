using NegoSudLib.DAO;
using System.ComponentModel.DataAnnotations;
namespace NegoSudLib.DTO.Write;

// Produit pour l'écriture dans la BDD
public class ProduitWriteDTO

{
    public int Id { get; set; }
    [Required]
    public string NomProduit { get; set; } = string.Empty;

    public int ContenanceCl { get; set; }
    public int QteEnStock { get; set; }

    public float DegreeAlcool { get; set; }
    public int Millesime { get; set; }
    public int QteCarton { get; set; }


    public string PhotoProduitPath { get; set; } = string.Empty;

    public string DescriptionProduit { get; set; } = string.Empty;

    public int SeuilCommandeMin { get; set; }

    public int CommandeMin { get; set; }

    public int IdDomaine { get; set; }

    public int IdCategorie { get; set; }
    public bool AlaVente { get; set; }
    public PrixAchat? PrixAchat { get; set; }
    public PrixVente? PrixVente { get; set; }
}
