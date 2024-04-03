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
    public interface IVentesRepository
    {
        Task<IEnumerable<VentesDTO>> GetAll();
        Task<VentesDTO?> GetById(int id);
        Task<VentesDTO?> GetByNum(string num);
        Task<VentesDTO?> Post(VentesWriteDTO vente);
        Task<VentesDTO?> Put(int id, VentesWriteDTO vente);
        Task Delete(int id);
        Task<bool> Exists(int id);
		Task<IEnumerable<VentesDTO>> GetAllOnline();
	}
}
