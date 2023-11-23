using System.ComponentModel.DataAnnotations;

namespace NegoSudLib.DAO
{
    public abstract class Utilisateur
    {
        [Key]
        [Required] 
        public int Id { get; set; }

        [StringLength(80)]
        public string NomUtilisateur { get; set; } = string.Empty;

        [StringLength(80)]
        public string PrenomUtilisateur { get; set; } = string.Empty;

        [StringLength(100)]
        public string AdresseUtilisateur { get; set; } = string.Empty;

        [StringLength(100)]
        public string MailUtilisateur { get; set; } = string.Empty;

        [StringLength(15)]
        public string NumTelUtilisateur { get; set; } = string.Empty;

        [StringLength(255)]
        public string HMotDePasse { get; set; } = string.Empty;
    }
}