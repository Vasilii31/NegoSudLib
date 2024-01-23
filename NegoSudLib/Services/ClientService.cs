using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<Client?> Post(Client Client)
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
