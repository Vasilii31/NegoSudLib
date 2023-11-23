using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public abstract class Prix
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }
        public float PrixCarton { get; set; }
        public float PrixUnite{ get; set; }

        [ForeignKey(nameof(Produit))]
        public int ProduitId {  get; set; }
        public Produit Produit { get; set; } = null!;
    }
}
