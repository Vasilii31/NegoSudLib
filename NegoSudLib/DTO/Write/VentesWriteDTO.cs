using NegoSudLib.DTO.Read;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO.Write;

public class VentesWriteDTO
{

	public string NumFacture { get; set; } = string.Empty;
	public string Commentaire { get; set; } = string.Empty;
	public int EmployeId { get; set; }
	[Required]
	public int ClientId { get; set; }
	public List<DetailMouvementStockDTO>? DetailMouvementStocks { get; set; } = [];

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
