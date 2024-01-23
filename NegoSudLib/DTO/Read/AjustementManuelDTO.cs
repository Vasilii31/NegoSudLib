/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO.Read;


public class AjustementManuelDTO
{
public int Id { get; set; }
public DateTime DateMouvement { get; set; }
public string Commentaire { get; set; } = string.Empty;
public string   NomEmploye { get; set; } = string.Empty;
public string   PrenomEmploye { get; set; } = string.Empty;
public string TypeMouvement { get; set; } = null!;

public ICollection<DetailMouvementStockDTO> DetailMouvementStocks { get; set; } = null!;
}
