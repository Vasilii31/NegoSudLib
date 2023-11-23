using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class PrixAchat : Prix
    {
        [ForeignKey(nameof(Fournisseur))]
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; } = null!;
    }
}
