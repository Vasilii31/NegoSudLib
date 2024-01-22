using NegoSudLib.DAO;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface IAutreMvtService
    {
        Task<IEnumerable<AutreMvtDTO>> GetAll();
        Task<AutreMvtDTO?> GetById(int id);
        Task<IEnumerable<AutreMvtDTO?>> GetByType(int typeId);
        Task<AutreMvtDTO?> Post(AutreMouvement autreMvt);
        Task<AutreMvtDTO?> Put(AutreMouvement autreMvt);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
