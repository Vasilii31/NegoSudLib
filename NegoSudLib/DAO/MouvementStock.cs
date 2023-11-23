using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class MouvementStock
    {
        [Key]
        [Required] 
        public int Id { get; set; }
        public int QteMouvement {  get; set; }
        public DateTime DateMouvement { get; set; }

        public bool EntreeOuSortie { get; set; }

        [StringLength(255)]
        public string Commentaire { get; set; } = string.Empty;

        //[ForeignKey(nameof(TypeMouvement))]
        //public int TypeMouvementId { get; set; }
        //public TypeMouvement TypeMouvement { get; set; } = null!;

        public virtual ICollection<DetailMouvementStock> DetailMouvementStocks { get; set; } = null!;

    }
}
