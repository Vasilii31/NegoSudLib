using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegoSudLib.DAO
{
    public class DetailMouvementStock
    {
        [Key]
        [Required] 
        public int Id { get; set; }

        public int QteProduit { get; set; }

        public float PrixApresRistourne { get; set; }
        public bool AuCarton { get; set; }

        [ForeignKey(nameof(MouvementsStock))]
        public int MouvementStockId { get; set; }
        public MouvementStock MouvementsStock { get; set; } = null!;
    }
}