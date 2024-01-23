using NegoSudLib.DTO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;

namespace NegoSudLib.Interfaces
{
    public interface IAutreMvtService
    {
        Task<IEnumerable<AutreMvtDTO>> GetAll();
        Task<AutreMvtDTO?> GetById(int id);
        Task<IEnumerable<AutreMvtDTO?>> GetByType(int typeId);
        Task<AutreMvtDTO?> Post(AutreMvtWriteDTO autreMvt);
        Task<AutreMvtDTO?> Put(int id, AutreMvtWriteDTO autreMvt);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
