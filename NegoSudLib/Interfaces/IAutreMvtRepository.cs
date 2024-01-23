using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface IAutreMvtRepository
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
