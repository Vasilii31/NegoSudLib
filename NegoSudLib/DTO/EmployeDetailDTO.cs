using System;
// Employé
namespace NegoSudLib.DTO;

public class EmployeDetailDTO
{
 
    public int Id { get; set; }

    public string NomUtilisateur { get; set; } = string.Empty;

    public string PrenomUtilisateur { get; set; } = string.Empty;

    public string AdresseUtilisateur { get; set; } = string.Empty;

    public string MailUtilisateur { get; set; } = string.Empty;

    public string NumTelUtilisateur { get; set; } = string.Empty;

    public string HMotDePasse { get; set; } = string.Empty;

    public bool Gerant { get; set; }

    public virtual ICollection<VenteDTO>? HistoriqueVentes { get; set; }
    public virtual ICollection<CommandeDTO>? HistoriqueCommande {  get; set; }
    public virtual ICollection<AjustementManuelDTO>? HistoriqueAjustement{  get; set; }
}
