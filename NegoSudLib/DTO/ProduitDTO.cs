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
    public string Domaine { get; set; } = string.Empty;
    public string Categorie { get; set; } = null!;
    public float PrixVente { get; set; }
    public float PrixAchat { get; set; }
}
