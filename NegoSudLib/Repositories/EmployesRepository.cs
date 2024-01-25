using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;

namespace NegoSudLib.Repositories
{
    public class EmployesRepository : BaseRepository, IEmployesRepository
    {
        private readonly UserManager<User> _userManager;

        public EmployesRepository(NegoSudDBContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<Employe>> GetAll()
        {
            return await _context.Employes
                            .Include(e => e.User)
                            .ToListAsync();
        }
        public async Task<Employe?> GetById(int id)
        {
            return await _context.Employes
                .Include(e => e.HistoriqueVentes)
                .Include(e => e.HistoriqueCommandes)
                .Include(e => e.HistoriqueAutreMouvements)
                .Include(e => e.User)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Employe?> GetByMail(string mail)
        {
            return await _context.Employes
            .Include(e => e.HistoriqueVentes)
            .Include(e => e.HistoriqueCommandes)
            .Include(e => e.HistoriqueAutreMouvements)
            .Include(e => e.User)
            .Where(e => e.User.Email == mail)
            .FirstOrDefaultAsync();
        }
        public async Task<EmployeDTO?> Post(EmployeDTO employe)
        {
            User user = new User()
            {
                UserName = employe.NomUtilisateur + employe.PrenomUtilisateur,
                Email = employe.MailUtilisateur
            };
            var result = await _userManager.CreateAsync(user, employe.MotDePasse);

            if (!result.Succeeded) return null;

            Employe empEntity = new Employe()
            {
                NomUtilisateur = employe.NomUtilisateur,
                PrenomUtilisateur = employe.PrenomUtilisateur,
                AdresseUtilisateur = employe.AdresseUtilisateur,
                NumTelUtilisateur = employe.NumTelUtilisateur,
                UserId = user.Id
            };

            await _context.Employes.AddAsync(empEntity);
            await _context.SaveChangesAsync();
            empEntity.User = user;
            EmployeDTO employeDTO = empEntity.ToDTO();
            return employeDTO;
        }
        public async Task<Employe?> Put(EmployeDTO employe)
        {
            var result = await _context.Employes
                .FirstOrDefaultAsync(e => e.Id == employe.Id);

            if (result != null)
            {
                result.NomUtilisateur = employe.NomUtilisateur;
                result.PrenomUtilisateur = employe.PrenomUtilisateur;
                //result.MailUtilisateur = employe.MailUtilisateur;
                result.AdresseUtilisateur = employe.AdresseUtilisateur;
                //result.HMotDePasse = employe.HMotDePasse;
                //result.Gerant = employe.Gerant;
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
