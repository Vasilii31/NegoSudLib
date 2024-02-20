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
    public void SetTotal()
    {
        if (DetailMouvementStocks != null)
        {
            foreach (var detMvt in DetailMouvementStocks)
            {
                this.Total += detMvt.SousTotal;
            }
        }

    }

}
