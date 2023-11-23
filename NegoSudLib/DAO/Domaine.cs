using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class Domaine
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string NomDomaine { get; set; } = string.Empty;

    }
}
