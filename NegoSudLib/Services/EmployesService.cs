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
    public class EmployesService : IEmployesService
    {

        private readonly IEmployesRepository _employesRepository;
        public EmployesService(IEmployesRepository employesRepository)
        {
            this._employesRepository = employesRepository;
        }
        public async Task<IEnumerable<Employe>> GetAll()
        {
            return await _employesRepository.GetAll();
        }
        public async Task<Employe?> GetById(int id)
        {
            return await _employesRepository.GetById(id);
        }

        public async Task<Employe?> GetByMail(string mail)
        {
            return await _employesRepository.GetByMail(mail);

        }

        public async Task<Employe?> Post(Employe employe)
        {
            return await _employesRepository.Post(employe);
        }
        public async Task<Employe?> Put(Employe employe)
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
