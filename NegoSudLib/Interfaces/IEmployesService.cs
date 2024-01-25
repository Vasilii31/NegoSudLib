﻿using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;

namespace NegoSudLib.Interfaces
{
    public interface IEmployesService
    {
        Task<IEnumerable<Employe>> GetAll();
        Task<Employe?> GetById(int id);
        Task<Employe?> GetByMail(string mail);
        Task<EmployeDTO?> Post(EmployeDTO Employe);
        Task<Employe?> Put(EmployeDTO Employe);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }

}