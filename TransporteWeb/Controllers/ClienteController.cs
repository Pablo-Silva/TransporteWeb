using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransporteWeb.Models;
using TransporteWeb.Models.View;
using TransporteWeb.Services;

namespace TransporteWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService service)
        {
            _clienteService = service;
        }
        public async Task<IActionResult> Index()
        {
            // Get Items from somewhere
            var clientes = await _clienteService.GetIncompleteItemsAsync();
            // Create a view model, if necessary
            var vm = new ClienteViewModel
            {
                Clientes = clientes
            };
            // Send to view
            return View(vm);
        }

        public async Task<IActionResult> AddItem(NewCliente newCliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var succesfull = await _clienteService.AddItemAsync(newCliente);

            if (!succesfull)
                return BadRequest(new { error = "Cold not add item" });
            return Ok();
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var successful = await _clienteService
                .MarkDoneAsync(id);

            if (!successful)
                return BadRequest(new { error = "Cold not mark item" });

            return Ok(successful);
        }
    }
}