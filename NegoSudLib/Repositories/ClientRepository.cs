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
    public class ClientRepository : BaseRepository, IClientRepository
    {

        public ClientRepository(NegoSudDBContext context) : base(context)
        {
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
        public async Task<Client?> Post(Client Client)
        {
            await _context.Clients.AddAsync(Client);
            await _context.SaveChangesAsync();
            return Client;
        }
        public async Task<Client?> Put(Client Client)
        {
            var result = await _context.Clients
                .FirstOrDefaultAsync(e => e.Id == Client.Id);

            if (result != null)
            {
                result.NomUtilisateur = Client.NomUtilisateur;
                result.PrenomUtilisateur = Client.PrenomUtilisateur;
                result.MailUtilisateur = Client.MailUtilisateur;
                result.AdresseUtilisateur = Client.AdresseUtilisateur;
                result.HMotDePasse = Client.HMotDePasse;
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
                _context.Clients.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id) 
        {
            return await _context.Clients.AnyAsync(e => e.Id == id);
        }
    }
}
