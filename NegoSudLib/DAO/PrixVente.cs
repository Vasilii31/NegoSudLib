using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class PrixVente : Prix
    {

        //nullable ?
        //[DecimalConstant(2, 0, )]
        public float Promotion { get; set; }

        //nullable ?
        //[DecimalConstant(2, 0, )]
        public float Taxe { get; set; }

    }
}
