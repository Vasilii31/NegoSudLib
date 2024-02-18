using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
    public class CategorieItemViewModel : ViewModelBase 
    {

        public CategorieDTO Categorie { get; set; }

        public CategorieItemViewModel(CategorieDTO cat)
        {
            Categorie = cat;
        }
    }
}
