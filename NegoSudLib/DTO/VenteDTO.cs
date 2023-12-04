using System;
namespace NegoSudLib.DTO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class VenteDTO
{
    public int Id { get; set; }
    public string NumFacture { get; set; } = string.Empty;
    public string NomClient{ get; set; } = string.Empty;
    public string PrenomClient { get; set; } = string.Empty;
    public int QteMouvement { get; set; }
    public DateTime DateMouvement { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    public string NomEmploye { get; set; } = string.Empty;
    public string PrenomEmploye { get; set; } = string.Empty;
    public  ICollection<DetailMouvementStockDTO> DetailMouvementStocks { get; set; } = null!;
}
