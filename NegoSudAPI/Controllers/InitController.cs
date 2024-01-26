using Microsoft.AspNetCore.Mvc;
using NegoSudLib.Interfaces;

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {

        private readonly IRolesService _rolesService;
        private readonly ISeedService _seedService;

        public InitController(IRolesService rolesService, ISeedService seedService)
        {
            _rolesService = rolesService;
            _seedService = seedService;
        }

        [HttpGet]
        public async Task InitAll()
        {
            await _rolesService.CreateRolesAsync();
            _seedService.SeedDB();
        }

    }
}
