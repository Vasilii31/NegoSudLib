using NegoSudLib.DTO;
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
        public int MouvementStockId { get; set; }
        
        [ForeignKey(nameof(Produit))]
        public int ProduitId { get; set; }
        public virtual Produit? Produit { get; set; }
    }
}