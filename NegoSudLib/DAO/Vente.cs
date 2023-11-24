using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegoSudLib.DAO
{
    public class Vente : MouvementStock
    {
        [StringLength(20)]
        public string NumFacture { get; set; } = string.Empty;

        [ForeignKey(nameof(Client))] 
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}