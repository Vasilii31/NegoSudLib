﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using NegoSudLib.Services;

namespace NegoSudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientsService;

        public ClientController(IClientService clientService)
        {
            _clientsService = clientService;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            var Client = await _clientsService.GetAll();
            if (Client.Any())
            {
                return Ok(Client);
            }
            return NotFound();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {

            var Clients = await _clientsService.GetById(id);
            if (Clients != null)
            {
                return Ok(Clients);
            }
            return NotFound();
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client Client)
        {
            if (!await _clientsService.Exists(id))
            {
                return NotFound();
            }
            if (Client != null)
            {
                var produitCreated = await _clientsService.Put(Client);
                if (produitCreated != null) return Ok(produitCreated);

                return StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
            // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
            return BadRequest("L'objet produit est null.");
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client Client)
        {
            if (Client != null)
            {
                var produitCreated = await _clientsService.Post(Client);
                if (produitCreated != null) return Ok(produitCreated);

                return StatusCode(500, "Une erreur interne du serveur s'est produite.");
            }
            // Retourne un statut 400 Bad Request si l'objet dans le corps de la requête est nul.
            return BadRequest("L'objet Client est null.");
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (!await _clientsService.Exists(id))
            {
                return NotFound(); // Renvoyer un code 404 si le produit n'est pas trouvé
            }

            await _clientsService.Delete(id);
            return NoContent();
        }

        
    }
}