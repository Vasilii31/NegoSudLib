using NegoSudLib.DAO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO;

public class VentesDTO
{
    public int Id { get; set; }
    public string NumFacture { get; set; } = string.Empty;
    public DateTime DateMouvement { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    public string NomEmploye { get; set; } = string.Empty;
    public string PrenomEmploye { get; set; } = string.Empty;
    public string NumClient { get; set; } = string.Empty;
    public string NomClient { get; set; } = string.Empty;
    public string PrenomClient { get; set; } = string.Empty;
    public IEnumerable<DetailMouvementStockDTO>? DetailMouvementStocks { get; set; }
    public float Total { get; set; }
    public void SetTotaux()
    {
        if (DetailMouvementStocks != null)
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

}
