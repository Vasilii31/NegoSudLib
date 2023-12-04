using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO;

public class CommandeDTO
{
    public int Id { get; set; }

    public string NumCommande { get; set; } = string.Empty;

    public DateTime DateMouvement { get; set; }

    public string Commentaire { get; set; } = string.Empty;

    public string NomEmploye { get; set; } = string.Empty;
    public string PrenomEmploye { get; set; } = string.Empty;

    public string NomFournisseur {  get; set; } = string.Empty;
    public string StatutCommande { get; set; } = string.Empty;

    public ICollection<DetailMouvementStockDTO> DetailMouvementStocks { get; set; } = null!;
}
