using NegoSudLib.DAO;
using System;
namespace NegoSudLib.DTO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MvtStockDTO
{
    public int Id { get; set; }
    public DateTime DateMouvement { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    public string NomEmploye { get; set; } = string.Empty;
    public string PrenomEmploye { get; set; } = string.Empty;
    public  ICollection<DetailMouvementStockDTO> DetailMouvementStocks { get; set; } = null!;
}
