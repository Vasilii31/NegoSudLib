using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class Client : Utilisateur
    {

        [StringLength(80)]
        public string NumClient { get; set; } = string.Empty;

        public virtual ICollection<Vente>? HistoriqueVentes { get; set;}

    }
}
