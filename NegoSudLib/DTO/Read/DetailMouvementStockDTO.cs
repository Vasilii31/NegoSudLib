using NegoSudLib.DAO;

namespace NegoSudLib.DTO.Read;

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

	public void SetSousTotal(bool EstVente)
	{
		if (AuCarton)
		{
			var prix = EstVente ? Produit.PrixVenteCarton : Produit.PrixAchatCarton;
			SousTotal = QteProduit * Produit.QteCarton * prix;
		}
		else
		{
			var prix = EstVente ? Produit.PrixVente : Produit.PrixAchat;
			SousTotal = QteProduit * prix;
		}
	}


	public DetailMouvementStock ToDAO()
	{
		return new DetailMouvementStock
		{
			Id = this.Id,
			QteProduit = this.QteProduit,
			PrixApresRistourne = this.PrixApresRistourne,
			AuCarton = this.AuCarton,
			MouvementStockId = this.MouvementStockId,
			ProduitId = this.ProduitId
		};
	}
}
