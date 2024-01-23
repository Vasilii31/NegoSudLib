using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Repositories
{
    public class EmployesRepository : BaseRepository, IEmployesRepository
    {

        public EmployesRepository(NegoSudDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employe>> GetAll()
        {
            return await _context.Employes.ToListAsync();
        }
        public async Task<Employe?> GetById(int id)
        {
            return await _context.Employes
                .Include(e => e.HistoriqueVentes)
                .Include(e => e.HistoriqueCommandes)
                .Include(e => e.HistoriqueAutreMouvements)
                .Where(e=> e.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Employe?> GetByMail(string mail)
        {
                return await _context.Employes
                .Include(e => e.HistoriqueVentes)
                .Include(e => e.HistoriqueCommandes)
                .Include(e => e.HistoriqueAutreMouvements)
                .Where(e=> e.MailUtilisateur == mail)
                .FirstOrDefaultAsync();
        }
        public async Task<Employe?> Post(Employe employe)
        {
            await _context.Employes.AddAsync(employe);
            await _context.SaveChangesAsync();
            return employe;
        }
        public async Task<Employe?> Put(Employe employe)
        {
            var result = await _context.Employes
                .FirstOrDefaultAsync(e => e.Id == employe.Id);

            if (result != null)
            {
                result.NomUtilisateur = employe.NomUtilisateur;
                result.PrenomUtilisateur = employe.PrenomUtilisateur;
                result.MailUtilisateur = employe.MailUtilisateur;
                result.AdresseUtilisateur = employe.AdresseUtilisateur;
                result.HMotDePasse = employe.HMotDePasse;
                result.Gerant = employe.Gerant;
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task Delete(int id)
        {
            var result = await _context.Employes
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _context.Employes.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id) 
        {
            return await _context.Employes.AnyAsync(e => e.Id == id);
        }
    }
}
