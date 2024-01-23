using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegoSudLib.DAO
{
    public class Commande : MouvementStock
    {
        public Statuts StatutCommande { get; set; }

        [StringLength(20)]
        public string NumCommande { get; set; } = string.Empty;

        [ForeignKey(nameof(Fournisseur))]
        public int FournisseurId { get; set; }
        public virtual Fournisseur? Fournisseur { get; set; }

    }

    public enum Statuts
    {
        ENVOYE,
        ENPREPARATION,
        AVALIDER,
        RECU,
        ANNULE
    }
}