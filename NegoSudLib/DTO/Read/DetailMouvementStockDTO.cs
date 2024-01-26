﻿namespace NegoSudLib.DTO.Read;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DetailMouvementStockDTO
{

    public int Id { get; set; }
    public int QteProduit { get; set; }
    public float PrixApresRistourne { get; set; }
    public bool AuCarton { get; set; }
    public int MouvementStockId { get; set; }
    public int ProduitId { get; set; }
    public ProduitLightDTO? Produit { get; set; }
    public float SousTotal { get; set; }
}
