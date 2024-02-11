using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;

namespace NegoSudLib.Repositories
{
    public class ProduitsRepository : BaseRepository, IProduitsRepository
    {
        public ProduitsRepository(NegoSudDBContext context) : base(context)
        {
        }
        public async Task<IEnumerable<ProduitLightDTO?>> GetAll(bool? AlaVente)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderByDescending(PrixAchat => PrixAchat.DateFin))
                .Include(p => p.PrixVentes.OrderByDescending(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => (AlaVente == null) ? true : p.AlaVente == AlaVente)
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();
        }
        public async Task<IEnumerable<ProduitLightDTO?>> GetByCat(int catId)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderByDescending(PrixAchat => PrixAchat.DateFin))
                .Include(p => p.PrixVentes.OrderByDescending(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => p.CategorieId == catId && p.AlaVente)
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();
        }
        public async Task<IEnumerable<ProduitLightDTO>> Search(int cat, int dom, string? name, bool? enVente)
        {

            return await _context.Produits
                .Include(p => p.PrixAchats.OrderByDescending(PrixAchat => PrixAchat.DateFin))
                .Include(p => p.PrixVentes.OrderByDescending(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => (enVente == null) || p.AlaVente == enVente)
                .Where(p => (cat == 0) || p.CategorieId == cat)
                .Where(p => (dom == 0) || p.DomaineId == dom)
                .Where(p => (string.IsNullOrEmpty(name)) || p.NomProduit.Contains(name))
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();
        }

        public async Task<IEnumerable<ProduitLightDTO?>> GetByDom(int domId)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderByDescending(PrixAchat => PrixAchat.DateFin))
                .Include(p => p.PrixVentes.OrderByDescending(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => p.DomaineId == domId && p.AlaVente)
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();
        }
        public async Task<ProduitFullDTO?> GetById(int id)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderByDescending(PrixAchat => PrixAchat.DateFin))
                .Include(p => p.PrixVentes.OrderByDescending(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => p.Id == id)
                .Select(p => p.ToFullDTO())
                .FirstOrDefaultAsync();
        }
        public async Task<ProduitLightDTO?> GetByIdDate(int id, DateTime date)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderByDescending(PrixAchat => PrixAchat.DateFin))
                .Include(p => p.PrixVentes.OrderByDescending(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => p.Id == id)
                .Select(p => p.ToLightDTO(date))
                .FirstOrDefaultAsync();
        }

        public async Task<ProduitFullDTO?> Post(ProduitWriteDTO prod)
        {
            Produit prodEntity = new Produit()
            {
                QteEnStock = prod.QteEnStock,
                NomProduit = prod.NomProduit,
                ContenanceCl = prod.ContenanceCl,
                DegreeAlcool = prod.DegreeAlcool,
                Millesime = prod.Millesime,
                DescriptionProduit = prod.DescriptionProduit,
                SeuilCommandeMin = prod.SeuilCommandeMin,
                CommandeMin = prod.CommandeMin,
                PhotoProduitPath = prod.PhotoProduitPath,
                QteCarton = prod.QteCarton,
                DomaineId = prod.IdDomaine,
                CategorieId = prod.IdCategorie,
                AlaVente = prod.AlaVente
            };
            _context.Produits.Add(prodEntity);
            await _context.SaveChangesAsync();
            return prodEntity.ToFullDTO();
        }
        public async Task<ProduitFullDTO?> Put(ProduitWriteDTO ProdNew)
        {
            Produit prodEntity = new Produit()
            {
                Id = ProdNew.Id,
                QteEnStock = ProdNew.QteEnStock,
                NomProduit = ProdNew.NomProduit,
                ContenanceCl = ProdNew.ContenanceCl,
                DegreeAlcool = ProdNew.DegreeAlcool,
                Millesime = ProdNew.Millesime,
                DescriptionProduit = ProdNew.DescriptionProduit,
                SeuilCommandeMin = ProdNew.SeuilCommandeMin,
                CommandeMin = ProdNew.CommandeMin,
                QteCarton = ProdNew.QteCarton,
                PhotoProduitPath = ProdNew.PhotoProduitPath,
                AlaVente = ProdNew.AlaVente,
                DomaineId = ProdNew.IdDomaine,
                CategorieId = ProdNew.IdCategorie
            };
            _context.Produits.Update(prodEntity);
            await _context.SaveChangesAsync();
            return prodEntity.ToFullDTO();
        }


        public async Task<bool> Exists(int id)
        {
            return await _context.Produits.AnyAsync(p => p.Id == id);
        }

        public async Task Delete(int id)
        {
            var product = await _context.Produits.FindAsync(id);

            if (product != null)
            {
                _context.Produits.Remove(product);
                await _context.SaveChangesAsync();
            }
        }




    }
}
