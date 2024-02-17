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
                .Include(p => p.PrixAchats.OrderBy(PrixAchat => PrixAchat.DateFin))
                .ThenInclude(p => p.Fournisseur)
                .Include(p => p.PrixVentes.OrderBy(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => (AlaVente == null) ? true : p.AlaVente == AlaVente)
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();
        }
        public async Task<IEnumerable<ProduitLightDTO?>> GetByCat(int catId)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderBy(PrixAchat => PrixAchat.DateFin))
                .ThenInclude(p => p.Fournisseur)
                .Include(p => p.PrixVentes.OrderBy(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => p.CategorieId == catId && p.AlaVente)
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();
        }
        public async Task<IEnumerable<ProduitLightDTO>> Search(int cat, int dom, int Four, string? name, bool? enVente)
        {

            var result = await _context.Produits
                .Include(p => p.PrixAchats.OrderBy(PrixAchat => PrixAchat.DateFin))
                .ThenInclude(p => p.Fournisseur)
                .Include(p => p.PrixVentes.OrderBy(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => (enVente == null) || p.AlaVente == enVente)
                .Where(p => (cat == 0) || p.CategorieId == cat)
                .Where(p => (dom == 0) || p.DomaineId == dom)
                .Where(p => (string.IsNullOrEmpty(name)) || p.NomProduit.Contains(name))
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();

            if (Four != 0)
            {
                return result.Where(p => p.IdFournisseur == Four);
            }
            return result;
        }

        public async Task<IEnumerable<ProduitLightDTO?>> GetByDom(int domId)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderBy(PrixAchat => PrixAchat.DateFin))
                .ThenInclude(p => p.Fournisseur)
                .Include(p => p.PrixVentes.OrderBy(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => p.DomaineId == domId && p.AlaVente)
                .Select(p => p.ToLightDTO(null))
                .ToListAsync();
        }
        public async Task<ProduitFullDTO?> GetById(int id)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderBy(PrixAchat => PrixAchat.DateFin))
                .ThenInclude(p => p.Fournisseur)
                .Include(p => p.PrixVentes.OrderBy(PrixVente => PrixVente.DateFin))
                .Include(p => p.Domaine)
                .Include(p => p.Categorie)
                .Where(p => p.Id == id)
                .Select(p => p.ToFullDTO())
                .FirstOrDefaultAsync();
        }
        public async Task<ProduitLightDTO?> GetByIdDate(int id, DateTime date)
        {
            return await _context.Produits
                .Include(p => p.PrixAchats.OrderBy(PrixAchat => PrixAchat.DateFin))
                .ThenInclude(p => p.Fournisseur)
                .Include(p => p.PrixVentes.OrderBy(PrixVente => PrixVente.DateFin))
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
        public async Task<ProduitFullDTO?> Put(int id, ProduitWriteDTO ProdNew)
        {

            Produit prodEntity = await _context.Produits.FindAsync(id);

            if (prodEntity == null) { return null; }

            /*  prodEntity.QteEnStock = ProdNew.QteEnStock;
              prodEntity.NomProduit = ProdNew.NomProduit == string.Empty ? prodEntity.NomProduit : ProdNew.NomProduit;
              prodEntity.ContenanceCl = ProdNew.ContenanceCl == 0 ? prodEntity.ContenanceCl : ProdNew.ContenanceCl;
              prodEntity.DegreeAlcool = ProdNew.DegreeAlcool;
              prodEntity.Millesime = ProdNew.Millesime == 0 ? prodEntity.Millesime : ProdNew.Millesime;
              prodEntity.DescriptionProduit = ProdNew.DescriptionProduit == string.Empty ? prodEntity.DescriptionProduit : ProdNew.DescriptionProduit;
              prodEntity.SeuilCommandeMin = ProdNew.SeuilCommandeMin;
              prodEntity.CommandeMin = ProdNew.CommandeMin;
              prodEntity.QteCarton = ProdNew.QteCarton == 0 ? prodEntity.QteCarton : ProdNew.QteCarton;
              prodEntity.PhotoProduitPath = ProdNew.PhotoProduitPath == string.Empty ? prodEntity.PhotoProduitPath : ProdNew.PhotoProduitPath;
              prodEntity.AlaVente = ProdNew.AlaVente;
              prodEntity.DomaineId = ProdNew.IdDomaine == 0 ? prodEntity.DomaineId : ProdNew.IdDomaine;
              prodEntity.CategorieId = ProdNew.IdCategorie == 0 ? prodEntity.CategorieId : ProdNew.IdCategorie;*/

            prodEntity.QteEnStock = ProdNew.QteEnStock;
            prodEntity.NomProduit = ProdNew.NomProduit;
            prodEntity.ContenanceCl = ProdNew.ContenanceCl;
            prodEntity.DegreeAlcool = ProdNew.DegreeAlcool;
            prodEntity.Millesime = ProdNew.Millesime;
            prodEntity.QteCarton = ProdNew.QteCarton;
            prodEntity.PhotoProduitPath = ProdNew.PhotoProduitPath;
            prodEntity.DescriptionProduit = ProdNew.DescriptionProduit;
            prodEntity.SeuilCommandeMin = ProdNew.SeuilCommandeMin;
            prodEntity.CommandeMin = ProdNew.CommandeMin;
            prodEntity.AlaVente = ProdNew.AlaVente;
            prodEntity.DomaineId = ProdNew.IdDomaine;
            prodEntity.CategorieId = ProdNew.IdCategorie;


            _context.Produits.Update(prodEntity);
            await _context.SaveChangesAsync();
            var pdtFull = prodEntity.ToFullDTO();
            return pdtFull;
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
