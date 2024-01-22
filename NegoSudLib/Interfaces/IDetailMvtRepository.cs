using NegoSudLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Interfaces
{
    public interface IDetailMvtRepository
    {
        Task<IEnumerable<DetailMouvementStock>> GetByMvt(int id);
        Task<DetailMouvementStock?> Post(DetailMouvementStock mvt);
        Task<DetailMouvementStock?> Put(DetailMouvementStock mvt);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
