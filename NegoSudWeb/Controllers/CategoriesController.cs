using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudWeb.Services;

namespace NegoSudWeb.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private ISession _session;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public CategoriesController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
							  SignInManager<User> signInManager)
		{
			_httpContextAccessor = httpContextAccessor;
			_session = _httpContextAccessor.HttpContext.Session;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		// GET: Categories
		public async Task<IActionResult> Index()
		{
			var categorie = await httpClientService.GetCategories();
			return View(categorie);
		}

		// GET: Categories/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var categorie = new List<string>();
			//var categorie = await _context.Categories
			//.FirstOrDefaultAsync(m => m.Id == id);*/
			if (categorie == null)
			{
				return NotFound();
			}

			return View(categorie);
		}

		// GET: Categories/Create
		public IActionResult Create()
		{
			return View();
		}





	}
}
