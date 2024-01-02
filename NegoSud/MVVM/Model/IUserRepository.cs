using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);


    }
}
