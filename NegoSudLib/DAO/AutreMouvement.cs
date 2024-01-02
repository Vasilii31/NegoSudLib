using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class AutreMouvement : MouvementStock
    {
        [ForeignKey(nameof(TypeMouvement))]
        public int TypeMouvementId { get; set; }
        public TypeMouvement TypeMouvement { get; set; } = null!;
    }
}
