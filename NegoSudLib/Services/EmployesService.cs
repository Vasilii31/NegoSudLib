using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Services
{
    public class EmployesService
    {
        private readonly NegoSudDBContext _context;
        private readonly VentesService _ventesService;
        private readonly CommandesService _commandesService;
        public EmployesService(NegoSudDBContext context)
        {
            _context = context;
            _ventesService = new VentesService(context);
            _commandesService = new CommandesService(context);
        }
        public ICollection<EmployeDTO> GetEmployes()
        {
            ICollection<EmployeDTO> employes =   _context.Employes.Select(e => new EmployeDTO
            {
                Id = e.Id,
                NomUtilisateur = e.NomUtilisateur,
                PrenomUtilisateur = e.PrenomUtilisateur,
                AdresseUtilisateur = e.AdresseUtilisateur,
                MailUtilisateur = e.MailUtilisateur,
                NumTelUtilisateur = e.NumTelUtilisateur,
                Gerant = e.Gerant,
            }).ToList();

            return  employes;
        }

        public EmployeDetailDTO? getEmployeById(int id)
        {
            Employe? employeEntitty = _context.Employes.Find(id);
            if (employeEntitty == null)
            {
                return null;
            }

            EmployeDetailDTO employe = employeToEmployeDetailDTO(employeEntitty);
            return employe;

         }

        public EmployeDTO? getEmployeByEmail(string email)
        {
            EmployeDTO? emp = _context.Employes
                .Where(e => e.MailUtilisateur == email)
                .Select( e => new EmployeDTO
                {
                    Id = e.Id,
                    NomUtilisateur = e.NomUtilisateur,
                    PrenomUtilisateur = e.PrenomUtilisateur,
                    AdresseUtilisateur = e.AdresseUtilisateur,
                    MailUtilisateur = e.MailUtilisateur,
                    NumTelUtilisateur = e.NumTelUtilisateur,
                    Gerant = e.Gerant
                }
                ).FirstOrDefault();
            if ( emp == null) {  return null; } 
            return emp;
        }

        public int addEmploye(EmployeDTO employe)
        {
            Employe employeEntity = new Employe
            {
                Id = employe.Id,
                NomUtilisateur = employe.NomUtilisateur,
                PrenomUtilisateur = employe.PrenomUtilisateur,
                AdresseUtilisateur = employe.AdresseUtilisateur,
                MailUtilisateur = employe.MailUtilisateur,
                NumTelUtilisateur = employe.NumTelUtilisateur,
                Gerant = employe.Gerant,
            };

            _context.Employes.Add(employeEntity);
            if (_context.SaveChanges() != 1)
            {
                return 0;
            };
            return employeEntity.Id;
        }

        public bool deleteEmploye(int id)
        {

            Employe? emp = _context.Employes.Find(id);
            if (emp != null)
            {
                _context.Employes.Remove(emp);
                if (_context.SaveChanges() == 1)
                {
                    return true;
                };
            }
            return false;
        }




        public EmployeDetailDTO employeToEmployeDetailDTO(Employe e)
        {

            EmployeDetailDTO employeDTO = new EmployeDetailDTO
            {
                Id = e.Id,
                NomUtilisateur = e.NomUtilisateur,
                PrenomUtilisateur = e.PrenomUtilisateur,
                AdresseUtilisateur = e.AdresseUtilisateur,
                MailUtilisateur = e.MailUtilisateur,
                NumTelUtilisateur = e.NumTelUtilisateur,
                Gerant = e.Gerant,

            };
            employeDTO.HistoriqueVentes = _ventesService.getVentesByEmploye(e.Id);
            employeDTO.HistoriqueCommandes = _commandesService.getCommandesByEmploye(e.Id);
            //TODO HistoriqueMvt 

            return employeDTO;
        }

    }
}
