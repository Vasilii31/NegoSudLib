using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface ICommandesService
    {
        Task<IEnumerable<CommandeDTO>> GetAll();
        Task<IEnumerable<CommandeDTO>> GetByStatut(Statuts statut);
        Task<CommandeDTO?> GetById(int id);
        Task<CommandeDTO?> GetByNum(string num);
        Task<CommandeDTO?> Post(CommandeWriteDTO commande);
        Task<CommandeDTO?> Put(int id, CommandeWriteDTO commande);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
