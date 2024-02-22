﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudWeb.Services;

namespace NegoSudWeb.Controllers
{
	public class ClientsController : Controller
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private ISession _session;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;


		public ClientsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
							  SignInManager<User> signInManager)
		{
			_httpContextAccessor = httpContextAccessor;
			_session = _httpContextAccessor.HttpContext.Session;
			_userManager = userManager;
			_signInManager = signInManager;
		}


		// GET: Clients
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			if (user == null) { RedirectToAction(nameof(Create)); }
			ClientDTO clientConnecté = await httpClientService.GetClientByUserName(user.UserName);
			return View(clientConnecté);
		}


		// GET: Clients/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Clients/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("UserName,NomUtilisateur,PrenomUtilisateur,AdresseUtilisateur,MailUtilisateur,NumTelUtilisateur,MotDePasse")] ClientDTO client)
		{

			if (ModelState.IsValid)
			{
				var clientAdded = await httpClientService.AddClient(client);
				return RedirectToAction(nameof(Index));
			}
			return View(client);
		}





		// GET: Clients/Login
		public async Task<IActionResult> Login()
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			if (user == null) return View();
			return RedirectToAction(nameof(Index));

		}
		// POST: Clients/Login
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([Bind("UserName,MotDePasse")] ClientDTO client)
		{

			if (ModelState.IsValid)
			{
				var result = _signInManager.PasswordSignInAsync(client.UserName, client.MotDePasse, true, lockoutOnFailure: false).Result;
				if (result.Succeeded) return RedirectToAction(nameof(Index));
			}

			return View(client);
		}


		// GET: Clients/LogOut
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			Response.Cookies.Delete("Panier");
			return RedirectToAction(nameof(Login));
		}

		// GET: Clients/Edit
		public async Task<IActionResult> Edit()
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			ClientDTO clientConnecté = await httpClientService.GetClientByUserName(user.UserName);
			if (user != null) return View(clientConnecté);
			return RedirectToAction(nameof(Index));
		}
		// POST: Clients/Edit

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit([Bind("UserName,NomUtilisateur,PrenomUtilisateur,AdresseUtilisateur,MailUtilisateur,NumTelUtilisateur,MotDePasse")] ClientDTO client)
		{

			if (ModelState.IsValid)
			{
				var result = _signInManager.PasswordSignInAsync(client.UserName, client.MotDePasse, true, lockoutOnFailure: false).Result;
				if (result.Succeeded) return RedirectToAction(nameof(Index));
			}

			return View(client);
		}





		/*  // GET: Clients/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var client = await _context.Clients
                  .Include(c => c.User)
                  .FirstOrDefaultAsync(m => m.Id == id);
              if (client == null)
              {
                  return NotFound();
              }

              return View(client);
          }

          // POST: Clients/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(int id)
          {
              var client = await _context.Clients.FindAsync(id);
              if (client != null)
              {
                  _context.Clients.Remove(client);
              }

              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }
    */

	}
}
