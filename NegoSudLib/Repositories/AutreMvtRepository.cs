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
    public class AutreMvtRepository : BaseRepository, IAutreMvtRepository
    {
        public AutreMvtRepository(NegoSudDBContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<AutreMvtDTO>> GetAll()
        {
            return await _context.AutreMouvements
                .Include(c => c.Employe)
                 .Include(c => c.TypeMouvement)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                .Select(c=> c.ToDTO())
                .ToListAsync();
        }

        public async Task<AutreMvtDTO?> GetById(int id)
        {
            var Vente = await _context.AutreMouvements
                 .Include(c => c.Employe)
                 .Include(c => c.TypeMouvement)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Where(c => c.Id == id)
                 .Select(c => c.ToDTO())
                 .FirstOrDefaultAsync();
            if (Vente == null) return null;
            Vente.SetTotaux();
            return Vente;
        }
        public async Task<IEnumerable<AutreMvtDTO?>> GetByType(int typeId)
        {
            return await _context.AutreMouvements
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixAchats)
                 .Include(c => c.DetailMouvementStocks).ThenInclude(p => p.Produit).ThenInclude(prix => prix.PrixVentes)
                 .Include(c => c.Employe)
                 .Include(c => c.TypeMouvement)
                 .Where(c => c.TypeMouvementId == typeId)
                 .Select(c => c.ToDTO())
                 .ToListAsync();
        }
        public async Task<AutreMvtDTO?> Post(AutreMouvement autreMvt)
        {
            await _context.AutreMouvements.AddAsync(autreMvt);
            await _context.SaveChangesAsync();
            return await GetById(autreMvt.Id);
        }

        public async Task<AutreMvtDTO?> Put(AutreMouvement autreMvt)
        {
            var result = await _context.AutreMouvements
                .FirstOrDefaultAsync(com => com.Id == autreMvt.Id);

            if (result != null)
            {
                result.EntreeOuSortie = autreMvt.EntreeOuSortie;
                result.QteMouvement = autreMvt.QteMouvement;
                result.Commentaire = autreMvt.Commentaire;
                result.EmployeId = autreMvt.EmployeId;
                result.DateMouvement = autreMvt.DateMouvement;
                await _context.SaveChangesAsync();

                var resultDTO = result.ToDTO();
                resultDTO.SetTotaux();
                return resultDTO;
            }
            return null;
        }
        public async Task Delete(int id)
        {
            var commnande = await _context.AutreMouvements.FindAsync(id);

            if (commnande != null)
            {
                _context.AutreMouvements.Remove(commnande);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.AutreMouvements.AnyAsync(c => c.Id == id);
        }
    }
}
