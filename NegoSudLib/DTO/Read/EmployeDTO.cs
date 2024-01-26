// Employé
namespace NegoSudLib.DTO.Read;

public class EmployeDTO
{

    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string NomUtilisateur { get; set; } = string.Empty;
    public string PrenomUtilisateur { get; set; } = string.Empty;
    public string AdresseUtilisateur { get; set; } = string.Empty;
    public string MailUtilisateur { get; set; } = string.Empty;
    public string NumTelUtilisateur { get; set; } = string.Empty;
    public string MotDePasse { get; set; } = string.Empty;
    public bool Gerant { get; set; }
}
