using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.write;

namespace NegoSudLib.Interfaces
{
    public interface ICommandesRepository
    {
        Task<IEnumerable<CommandeDTO>> GetAll();
        Task<IEnumerable<CommandeDTO>> GetByStatut(Statuts statut);
        Task<CommandeDTO?> GetById(int id);
        Task<CommandeDTO?> GetByNum(string num);
        Task<CommandeDTO?> Post(CommandeWriteDTO commande);
        Task<CommandeDTO?> Put(int id,CommandeWriteDTO commande);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
