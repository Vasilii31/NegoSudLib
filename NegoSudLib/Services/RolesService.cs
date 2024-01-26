using Microsoft.AspNetCore.Identity;
using NegoSudLib.Interfaces;

namespace NegoSudLib.Services
{
    public class RolesService : IRolesService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task CreateRolesAsync()
        {
            string[] roleNames = { "Gérant", "Employé", "Client" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    // Créer le rôle s'il n'existe pas
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }

}
