using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;

namespace NegoSudLib.Interfaces
{
    public interface IEmployesRepository
    {
        Task<IEnumerable<EmployeDTO>> GetAll();
        Task<EmployeDTO?> GetById(int id);
        Task<EmployeDTO?> GetByMail(string mail);
        Task<EmployeDTO?> Post(EmployeDTO Employe);
        Task<Employe?> Put(EmployeDTO Employe);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
