using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.NegosudDbContext;
using System;
namespace NegoSudLib.DTO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ProduitWriteDTO

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
    public int CategorieId { get; set; }
    public PrixVenteDTO PrixVenteActuel { get; set; } = null!;
    public PrixAchatWriteDTO PrixAchatActuel {  get; set; } = null!; 

}
