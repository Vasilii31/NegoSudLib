using NegoSudLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface IEmployesService
    {
        Task<IEnumerable<Employe>> GetAll();
        Task<Employe?> GetById(int id);
        Task<Employe?> GetByMail(string mail);
        Task<Employe?> Post(Employe Employe);
        Task<Employe?> Put(Employe Employe);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }

}
