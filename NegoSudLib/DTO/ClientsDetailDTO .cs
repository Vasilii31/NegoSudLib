using System;
// client
namespace NegoSudLib.DTO;

public class ClientDetailDTO
{
 
    public int Id { get; set; }

    public string NomUtilisateur { get; set; } = string.Empty;

    public string PrenomUtilisateur { get; set; } = string.Empty;

    public string AdresseUtilisateur { get; set; } = string.Empty;

    public string MailUtilisateur { get; set; } = string.Empty;

    public string NumTelUtilisateur { get; set; } = string.Empty;

    public string HMotDePasse { get; set; } = string.Empty;

    public string NumClient { get; set; } = string.Empty;

    public virtual ICollection<VentesDTO>? HistoriqueVentes { get; set; }
}
