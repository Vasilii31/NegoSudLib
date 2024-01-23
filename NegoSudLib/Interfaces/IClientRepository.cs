using NegoSudLib.DAO;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client?> GetById(int id);
        Task<Client?> Post(Client Client);
        Task<Client?> Put(Client Client);
        Task Delete(int id);
        Task<bool> Exists(int id);

    }
}
