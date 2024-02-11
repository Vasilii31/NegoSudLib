using System.ComponentModel.DataAnnotations;

namespace NegoSudLib.DAO
{
    public class Client : Utilisateur
    {

        [StringLength(80)]
        public string NumClient { get; set; } = string.Empty;

        public virtual IEnumerable<Vente>? HistoriqueVentes { get; set; }

    }
}
