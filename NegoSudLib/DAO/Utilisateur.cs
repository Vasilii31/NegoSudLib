using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegoSudLib.DAO
{
    public abstract class Utilisateur
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;
        public virtual User User { get; set; } = null!;

        [StringLength(80)]
        public string NomUtilisateur { get; set; } = string.Empty;

        [StringLength(80)]
        public string PrenomUtilisateur { get; set; } = string.Empty;

        [StringLength(100)]
        public string AdresseUtilisateur { get; set; } = string.Empty;

        [StringLength(15)]
        public string NumTelUtilisateur { get; set; } = string.Empty;
    }
}