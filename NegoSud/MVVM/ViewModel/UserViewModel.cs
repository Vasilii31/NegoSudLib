using NegoSudLib.DTO;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel
{
    
    public class UserViewModel
    {
        public EmployeDTO Employe { get; }

        public UserViewModel(EmployeDTO employe)
        {
            Employe = employe;
        }
    }
}
