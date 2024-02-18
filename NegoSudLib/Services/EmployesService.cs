using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.Interfaces;

namespace NegoSudLib.Services
{
    public class EmployesService : IEmployesService
    {

        private readonly IEmployesRepository _employesRepository;
        public EmployesService(IEmployesRepository employesRepository)
        {
            this._employesRepository = employesRepository;
        }
        public async Task<IEnumerable<EmployeDTO>> GetAll()
        {
            return await _employesRepository.GetAll();
        }
        public async Task<EmployeDTO?> GetById(int id)
        {
            return await _employesRepository.GetById(id);
        }

        public async Task<EmployeDTO?> GetByMail(string mail)
        {
            return await _employesRepository.GetByMail(mail);

        }
        public async Task<EmployeDTO?> GetByUserName(string userName)
        {
            return await _employesRepository.GetByUserName(userName);

        }

        public async Task<EmployeDTO?> Post(EmployeDTO employe)
        {
            return await _employesRepository.Post(employe);
        }
        public async Task<Employe?> Put(EmployeDTO employe)
        {
            return await _employesRepository.Put(employe);
        }
        public async Task Delete(int id)
        {
            await _employesRepository.Delete(id);
        }
        public Task<bool> Exists(int id)
        {
            return _employesRepository.Exists(id);
        }




    }
}
