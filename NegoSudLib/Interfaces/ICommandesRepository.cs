using NegoSudLib.DAO;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface ICommandesRepository
    {
        Task<IEnumerable<CommandeDTO>> GetAll();
        Task<CommandeDTO?> GetById(int id);
        Task<CommandeDTO?> GetByNum(string num);
        Task<CommandeDTO?> Post(Commande commande);
        Task<CommandeDTO?> Put(Commande commande);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
