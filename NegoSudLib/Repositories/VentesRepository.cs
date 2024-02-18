using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;

namespace NegoSudLib.Repositories
{
    public class VentesRepository : BaseRepository, IVentesRepository
    {
        public VentesRepository(NegoSudDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VentesDTO>> GetAll()
        {

            return await _context.Ventes
                .Include(c => c.Client)
                .Include(c => c.Employe)
                .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Categorie)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Domaine)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                .Select(c => c.ToDTO())
                .ToListAsync();
            //return await _context.Ventes
            //    .Include(c => c.Client)
            //    .Include(c => c.Employe)
            //    .Select(c => c.ToDTO())
            //    .ToListAsync();
        }

        public async Task<VentesDTO?> GetById(int id)
        {
            var Vente = await _context.Ventes
                 .Include(c => c.Client)
                 .Include(c => c.Employe)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Categorie)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Domaine)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Where(c => c.Id == id)
                 .Select(c => c.ToDTO())
                 .FirstOrDefaultAsync();
            if (Vente == null) return null;
            Vente.SetTotaux();
            return Vente;
        }
        public async Task<VentesDTO?> GetByNum(string num)
        {
            var Vente = await _context.Ventes
                 .Include(c => c.Client)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Categorie)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(p => p.Domaine)
                 .Include(c => c.Employe)
                 .Where(c => c.NumFacture == num)
                 .Select(c => c.ToDTO())
                 .FirstOrDefaultAsync();
            if (Vente == null) return null;
            // On calcule les Totaux
            Vente.SetTotaux();
            return Vente;
        }
        public async Task<VentesDTO?> Post(VentesWriteDTO VenteDTO)
        {
            List<DetailMouvementStock> DetailMvt = [];
            foreach (var item in VenteDTO.DetailMouvementStocks)
            {
                DetailMvt.Add(item.ToDAO());
            }
            Vente Vente = new Vente
            {
                DateMouvement = DateTime.Now,
                EmployeId = VenteDTO.EmployeId,
                ClientId = VenteDTO.ClientId,
                EntreeOuSortie = false,
                DetailMouvementStocks = DetailMvt,
                Commentaire = VenteDTO.Commentaire
            };
            await _context.Ventes.AddAsync(Vente);
            await _context.SaveChangesAsync();
            Vente.NumFacture = "FAC" + Vente.Id;
            await _context.SaveChangesAsync();
            return await GetById(Vente.Id);
        }

        public async Task<VentesDTO?> Put(int id, VentesWriteDTO Vente)
        {
            var result = await _context.Ventes.FindAsync(id);

            if (result != null)
            {
                result.Commentaire = Vente.Commentaire;
                result.EmployeId = Vente.EmployeId;
                result.ClientId = Vente.ClientId;
                await _context.SaveChangesAsync();
                var resultDTO = result.ToDTO();
                resultDTO.SetTotaux();
                return resultDTO;
            }
            return null;
        }
        public async Task Delete(int id)
        {
            var commnande = await _context.Ventes.FindAsync(id);

            if (commnande != null)
            {
                _context.Ventes.Remove(commnande);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.Ventes.AnyAsync(c => c.Id == id);
        }
    }
}
