using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public abstract class MouvementStock
    {
        public int Id { get; set; }
        public int QteMouvement {  get; set; } //Nombre de ligne
        public DateTime DateMouvement { get; set; }
        public bool EntreeOuSortie { get; set; }
        public string Commentaire { get; set; } = string.Empty;
        public int EmployeId { get; set; }
        public virtual Employe? Employe { get; set; }
        public virtual IEnumerable<DetailMouvementStock>? DetailMouvementStocks { get; set; }

    }
}
