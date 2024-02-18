using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DTO.Read
{
    public class DomaineDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string NomDomaine { get; set; } = string.Empty;
    }
}
