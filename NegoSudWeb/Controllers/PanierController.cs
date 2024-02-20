using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NegoSudWeb.Controllers
{
	public class PanierController : Controller
	{
		// GET: PanierController
		public ActionResult Index()
		{
			return View();
		}

		// GET: PanierController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PanierController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PanierController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PanierController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PanierController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PanierController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PanierController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
