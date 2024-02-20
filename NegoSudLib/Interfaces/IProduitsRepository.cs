using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;

namespace NegoSudLib.Interfaces
{
    public interface IProduitsRepository
    {
        Task<IEnumerable<ProduitLightDTO>> GetAll(bool? AlaVente);
        Task<IEnumerable<ProduitLightDTO>> GetByCat(int catId);
        Task<IEnumerable<ProduitLightDTO>> GetByDom(int domId);
        Task<ProduitLightDTO?> GetById(int id);
        Task<ProduitLightDTO?> GetByIdDate(int id, DateTime date);
        Task<ProduitFullDTO?> Post(ProduitWriteDTO prod);
        Task<ProduitFullDTO?> Put(int id, ProduitWriteDTO ProdNew);
        Task Delete(int id);
        Task<bool> Exists(int id);
        Task<IEnumerable<ProduitLightDTO>> Search(int cat, int dom, int Four, string? name, bool? enVente);
        Task<IEnumerable<ProduitLightDTO>> GetAllProductsLow();
    }
}
