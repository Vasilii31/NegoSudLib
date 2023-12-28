using System;
namespace NegoSudLib.DTO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DetailMouvementStockDTO
{
    public int QteProduit { get; set; }
    public float PrixApresRistourne { get; set; }
    public bool AuCarton { get; set; }
    public int produitId { get; set; }
    public ProduitReadDTO Produit { get; set; } = null!;
}
