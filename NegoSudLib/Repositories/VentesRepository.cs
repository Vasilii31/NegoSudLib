﻿using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.Extensions;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                .Select(c=> c.ToDTO())
                .ToListAsync();
        }

        public async Task<VentesDTO?> GetById(int id)
        {
            var Vente = await _context.Ventes
                 .Include(c => c.Client)
                 .Include(c => c.Employe)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
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
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p=>p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p=>p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Include(c=> c.Employe)
                 .Where(c => c.NumFacture == num)
                 .Select(c => c.ToDTO())
                 .FirstOrDefaultAsync();
            if (Vente == null) return null;
            // On calcule les Totaux
            Vente.SetTotaux();
            return Vente;
        }
        public async Task<VentesDTO?> Post(Vente Vente)
        {
            await _context.Ventes.AddAsync(Vente);
            await _context.SaveChangesAsync();
            return await this.GetById(Vente.Id);
        }

        public async Task<VentesDTO?> Put(Vente Vente)
        {
            var result = await _context.Ventes
                .FirstOrDefaultAsync(com => com.Id == Vente.Id);

            if (result != null)
            {
                result.EntreeOuSortie = Vente.EntreeOuSortie;
                result.NumFacture = Vente.NumFacture;
                result.QteMouvement = Vente.QteMouvement;
                result.Commentaire = Vente.Commentaire;
                result.EmployeId = Vente.EmployeId;
                result.DateMouvement = Vente.DateMouvement;
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
