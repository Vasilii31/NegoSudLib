using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.NegosudDbContext;
using System;
namespace NegoSudLib.DTO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ProduitReadDTO
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
    public Domaine? Domaine { get; set; }
    public Categorie Categorie { get; set; } = null!;
    public PrixVenteDTO? PrixVente { get; set; }
    public PrixAchatReadDTO? PrixAchat {  get; set; }

}
