using System;
namespace NegoSudLib.DTO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ProduitDTO
{
    public int Id { get; set; }
    public int QteEnStock { get; set; }
    public string NomProduit { get; set; } = string.Empty;
    public int ContenanceCl { get; set; }
    public float DegreeAlcool { get; set; }
    public int Millesime { get; set; }
    public string DescriptionProduit { get; set; } = string.Empty;
    public int QteCarton { get; set; }
    public string PhotoProduitPath { get; set; } = string.Empty;
    public int DomaineId { get; set; }
    public string NomDomaine { get; set; } = string.Empty;
    public int CategorieId { get; set; }
    public string NomCategorie { get; set; } = null!;
    public float PrixVenteUnite { get; set; }
    public float PrixVenteCarton{ get; set; }
    public float PrixAchatUnite { get; set; }
    public float PrixAchatCarton { get; set; }
    public float Taxe { get; set; }
    public int FournisseurId { get; set; }

}
