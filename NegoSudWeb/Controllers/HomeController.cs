using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudWeb.Models;
using System.Diagnostics;

namespace NegoSudWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
                              SignInManager<User> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null && string.IsNullOrEmpty(_session.GetString("InfoClient")))
            {
                string token = Request.Cookies[".AspNetCore.Identity.Application"];
                //httpClientService.Refresh(token);
            }
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
