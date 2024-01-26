using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;

namespace NegoSudLib.Interfaces
{
    public interface IVentesService
    {
        Task<IEnumerable<VentesDTO>> GetAll();
        Task<VentesDTO?> GetById(int id);
        Task<VentesDTO?> GetByNum(string num);
        Task<VentesDTO?> Post(VentesWriteDTO vente);
        Task<VentesDTO?> Put(int id, VentesWriteDTO vente);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
