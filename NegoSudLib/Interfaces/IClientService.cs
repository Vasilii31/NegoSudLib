using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;

namespace NegoSudLib.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client?> GetById(int id);
        Task<ClientDTO?> Post(ClientDTO Client);
        Task<Client?> Put(Client Client);
        Task Delete(int id);
        Task<bool> Exists(int id);
        Task<ClientDTO> GetByUserName(string userName);
    }

}
