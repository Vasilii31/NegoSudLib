using NegoSudLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface IProduitsServices
    {
        Task<IEnumerable<ProduitLightDTO>> GetAll(bool? AlaVente);
        Task<IEnumerable<ProduitLightDTO>> GetByCat(int catId);
        Task<IEnumerable<ProduitLightDTO>> GetByDom(int domId);
        Task<ProduitFullDTO?> GetById(int id);
        Task<ProduitLightDTO?> GetByIdDate(int id, DateTime date);
        Task<ProduitFullDTO?> Post(ProduitWriteDTO prod);
        Task<ProduitFullDTO?> Put(ProduitWriteDTO ProdNew);
        Task Delete(int id);
        Task<bool> Exists(int id);


    }
}
