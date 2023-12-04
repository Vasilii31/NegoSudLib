using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class Categorie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string NomCategorie { get; set; } = string.Empty;
    }
}
