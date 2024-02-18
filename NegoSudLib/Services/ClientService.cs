using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.Interfaces;

namespace NegoSudLib.Services
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }
        public async Task<Client?> GetById(int id)
        {
            return await _clientRepository.GetById(id);
        }
        public async Task<ClientDTO?> Post(ClientDTO Client)
        {
            return await _clientRepository.Post(Client);
        }
        public async Task<Client?> Put(Client Client)
        {
            return await _clientRepository.Put(Client);
        }
        public async Task Delete(int id)
        {
            await _clientRepository.Delete(id);
        }
        public Task<bool> Exists(int id)
        {
            return _clientRepository.Exists(id);
        }




    }
}
