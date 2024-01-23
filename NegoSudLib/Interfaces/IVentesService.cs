using NegoSudLib.DAO;
using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface IVentesService
    {
        Task<IEnumerable<VentesDTO>> GetAll();
        Task<VentesDTO?> GetById(int id);
        Task<VentesDTO?> GetByNum(string num);
        Task<VentesDTO?> Post(Vente vente);
        Task<VentesDTO?> Put(Vente vente);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
