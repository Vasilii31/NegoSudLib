using NegoSudLib.DAO;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO;

public class AutreMvtDTO
{
    public int Id { get; set; }
    public string NumCommande { get; set; } = string.Empty;
    public DateTime DateMouvement { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    public string NomEmploye { get; set; } = string.Empty;
    public string PrenomEmploye { get; set; } = string.Empty;
    public int TypeMouvementId { get; set; }
    public TypeMouvement TypeMouvement { get; set; } = null!;
    public IEnumerable<DetailMouvementStockDTO>? DetailMouvementStocks { get; set; }
    public float Total { get; set; }
    public void SetTotaux()
    {
        foreach (var detMvt in DetailMouvementStocks)
        {
            if (detMvt.PrixApresRistourne < 0)
            {
                float prix = detMvt.AuCarton ? detMvt.Produit.PrixAchatCarton : detMvt.Produit.PrixAchat;
                detMvt.SousTotal = detMvt.QteProduit * prix;
            }
            else
            {
                detMvt.SousTotal = detMvt.PrixApresRistourne;
            }
            this.Total += detMvt.SousTotal;
        }
    }

}
