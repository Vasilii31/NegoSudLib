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
        private readonly RoleManager<IdentityRole> _roleManager;


        public EmployesRepository(NegoSudDBContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<EmployeDTO>> GetAll()
        {
            var employes = await _context.Employes
                            .Include(e => e.User)
                            .ToListAsync();

            IEnumerable<EmployeDTO> employesDTO = new List<EmployeDTO>();
            if (employes.Count != 0)
            {
                foreach (var employe in employes)
                {

                    var isGerant = await _userManager.IsInRoleAsync(employe.User, "Gérant");

                    EmployeDTO employeDTO = employe.ToDTO(isGerant);

                    employesDTO = employesDTO.Append(employeDTO);
                }
            }

            return employesDTO;
        }
        public async Task<EmployeDTO?> GetById(int id)
        {
            var employe = await _context.Employes
            .Include(e => e.User)
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

            if (employe == null) return null;

            var isGerant = await _userManager.IsInRoleAsync(employe.User, "Gérant");

            return employe.ToDTO(isGerant);
        }
        public async Task<EmployeDTO?> GetByMail(string mail)
        {
            var employe = await _context.Employes
            .Include(e => e.User)
            .Where(e => e.User.Email == mail)
            .FirstOrDefaultAsync();

            if (employe == null) return null;

            var isGerant = await _userManager.IsInRoleAsync(employe.User, "Gérant");

            return employe.ToDTO(isGerant);

        }
        public async Task<EmployeDTO?> GetByUserName(string userName)
        {
            var employe = await _context.Employes
            .Include(e => e.User)
            .Where(e => e.User.UserName == userName)
            .FirstOrDefaultAsync();

            if (employe == null) return null;

            var isGerant = await _userManager.IsInRoleAsync(employe.User, "Gérant");

            return employe.ToDTO(isGerant);

        }
        public async Task<EmployeDTO?> Post(EmployeDTO employe)
        {
            User user = new User()
            {
                UserName = employe.UserName,
                Email = employe.MailUtilisateur
            };
            var result = await _userManager.CreateAsync(user, employe.MotDePasse);

            if (employe.Gerant)
            {
                await _userManager.AddToRoleAsync(user, "Gérant");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Employé");
            }

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
            var isGerant = await _userManager.IsInRoleAsync(user, "Gérant");
            EmployeDTO employeDTO = empEntity.ToDTO(isGerant);
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
