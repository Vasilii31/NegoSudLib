using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using NegoSudLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Services
{
    public class DetailMvtService : IDetailMvtService
    {

        public readonly IDetailMvtRepository _detailMvtRepository;
        public DetailMvtService(IDetailMvtRepository detailMvtService)
        {
            this._detailMvtRepository = detailMvtService;
        }

        public async Task<IEnumerable<DetailMouvementStock>> GetByMvt(int id)
        {
            return  await _detailMvtRepository.GetByMvt(id);
        }

        public async Task<DetailMouvementStock?> Post(DetailMouvementStock mvt)
        {
            return await _detailMvtRepository.Post(mvt);
        }

        public async Task<DetailMouvementStock?> Put(DetailMouvementStock mvt)
        {
            return await _detailMvtRepository.Put(mvt);
        }

        public async Task Delete(int id)
        {
            await _detailMvtRepository.Delete(id);
        }
        public async Task<bool> Exists(int id)
        {
            return await _detailMvtRepository.Exists(id);

        }
    }
}
