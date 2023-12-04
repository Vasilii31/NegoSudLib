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
    public ProduitDTO Produit { get; set; } = null!;
}
