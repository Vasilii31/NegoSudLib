using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;

namespace NegoSudLib.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        private readonly UserManager<User> _userManager;

        public ClientRepository(NegoSudDBContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }
        public async Task<Client?> GetById(int id)
        {
            return await _context.Clients
                .Include(c => c.HistoriqueVentes)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<ClientDTO?> Post(ClientDTO Client)
        {
            User user = new User()
            {
                UserName = Client.UserName,
                Email = Client.MailUtilisateur
            };
            var result = await _userManager.CreateAsync(user, Client.MotDePasse);
            if (!result.Succeeded) return null;
            await _userManager.AddToRoleAsync(user, "Client");
            Client cliEntity = new Client()
            {
                NomUtilisateur = Client.NomUtilisateur,
                PrenomUtilisateur = Client.PrenomUtilisateur,
                AdresseUtilisateur = Client.AdresseUtilisateur,
                NumTelUtilisateur = Client.NumTelUtilisateur,
                UserId = user.Id
            };
            await _context.Clients.AddAsync(cliEntity);
            await _context.SaveChangesAsync();
            cliEntity.NumClient = "CLI" + cliEntity.Id;
            await _context.SaveChangesAsync();
            return cliEntity.toDTO();
        }
        public async Task<Client?> Put(Client Client)
        {
            var result = await _context.Clients
                .FirstOrDefaultAsync(e => e.Id == Client.Id);

            if (result != null)
            {
                result.NomUtilisateur = Client.NomUtilisateur;
                result.PrenomUtilisateur = Client.PrenomUtilisateur;
                //result.MailUtilisateur = Client.MailUtilisateur;
                result.AdresseUtilisateur = Client.AdresseUtilisateur;
                // result.HMotDePasse = Client.HMotDePasse;
                result.NumClient = Client.NumClient;
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task Delete(int id)
        {

            var result = await _context.Clients
              .FirstOrDefaultAsync(e => e.Id == id);



            if (result != null)
            {
                var usr = await _userManager.FindByIdAsync(result.UserId);
                if (usr != null)
                {
                    await _userManager.DeleteAsync(usr);
                    _context.Clients.Remove(result);
                    // await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Clients.AnyAsync(e => e.Id == id);
        }
    }
}
