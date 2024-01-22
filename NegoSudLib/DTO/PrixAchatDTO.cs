using NegoSudLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DTO
{
    public class PrixAchatDTO
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; } = null;
        public float PrixCarton { get; set; }
        public float PrixUnite { get; set; }
        public int ProduitId { get; set; }
        public string NomFournisseur { get; set; } = string.Empty;

    }
}
