using NegoSudLib.DAO;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO.Write;

public class VentesWriteDTO
{

    public string NumFacture { get; set; } = string.Empty;
    public string Commentaire { get; set; } = string.Empty;
    [Required]
    public int EmployeId { get; set; }
    [Required]
    public int ClientId { get; set; }
    public IEnumerable<DetailMouvementStock>? DetailMouvementStocks { get; set; }

}
