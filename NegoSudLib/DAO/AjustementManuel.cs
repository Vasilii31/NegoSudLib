using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class AjustementManuel : MouvementStock
    {
        [ForeignKey(nameof(Employe))]
        public int EmployeId { get; set; }
        public Employe Employe { get; set; } = null!;
    }
}
