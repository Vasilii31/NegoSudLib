using NegoSudLib.DAO;
using NegoSudLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DTO.Read
{
    public class PrixVenteDTO
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; } = null;
        public float PrixCarton { get; set; }
        public float PrixUnite { get; set; }
        public int ProduitId { get; set; }
        public float Promotion { get; set; }
        public float Taxe { get; set; }
    }
}
