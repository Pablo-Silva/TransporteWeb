using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteWeb.Data;
using TransporteWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace TransporteWeb.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(NewCliente newCliente)
        {
            var entity = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                NomeCliente = newCliente.NomeCliente,
                Cpf = newCliente.Cpf,
                NumeroCelular = newCliente.NumeroCelular,
                Email = newCliente.Email,
                Senha = newCliente.Senha,
                Deficiencia = newCliente.Deficiencia
            };

            _context.Clientes.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<IEnumerable<Cliente>> GetIncompleteItemsAsync()
        {
            var clientes = await _context.Clientes
                .ToArrayAsync();

            return clientes;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var clientes = await _context.Clientes
                .Where(x => x.IdCliente == id)
                .SingleOrDefaultAsync();

            if (clientes == null)
                return false;

            clientes.IsDone = true;

            var saveResult = await _context
                .SaveChangesAsync();

            // One entity should
            // have been updated
            return saveResult == 1;
        }
    } 
}
