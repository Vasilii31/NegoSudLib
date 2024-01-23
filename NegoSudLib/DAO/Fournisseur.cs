using System.ComponentModel.DataAnnotations;

namespace NegoSudLib.DAO
{
    public class Fournisseur
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string NomFournisseur { get; set; } = string.Empty;

        [StringLength(100)]
        public string AdresseFournisseur { get; set; } = string.Empty;

        [StringLength(15)]
        public string NumTelFournisseur { get; set; } = string.Empty;

        [StringLength(20)]
        public string EmailFournisseur { get; set; } = string.Empty;
    }
}