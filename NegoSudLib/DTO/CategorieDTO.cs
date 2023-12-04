using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DTO
{
    public class CategorieDTO
    {

        public int Id { get; set; }

        public string NomCategorie { get; set; } = string.Empty;
    }
}
