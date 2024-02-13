using NegoSudLib.DAO;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO.Write;

public class AutreMvtWriteDTO
{
    [Required]
    public DateTime DateMouvement { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    [Required]
    public bool EntreeOuSortie { get; set; }
    [Required]
    public int EmployeId { get; set; }
    [Required]
    public int TypeMouvementId { get; set; }
    public List<DetailMouvementStock>? DetailMouvementStocks { get; set; }
}
