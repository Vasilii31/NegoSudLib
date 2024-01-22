using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly NegoSudDBContext _context;

        public BaseRepository(NegoSudDBContext context)
        {
            _context = context;
        }
    }
}
