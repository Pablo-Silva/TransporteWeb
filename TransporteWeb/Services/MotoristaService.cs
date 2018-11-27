using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteWeb.Data;
using TransporteWeb.Models;

namespace TransporteWeb.Services
{
    public class MotoristaService : IMotoristaService
    {
        private readonly ApplicationDbContext _context;

        public MotoristaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(NewMotorista newMotorista)
        {
            var entity = new Motorista
            {
                IdMotorista = Guid.NewGuid(),
                NomeMotorista = newMotorista.NomeMotorista,
                Cpf = newMotorista.Cpf,
                NumeroCelular = newMotorista.NumeroCelular,
                Email = newMotorista.Email,
                Senha = newMotorista.Senha,
                Ativo = newMotorista.Ativo,
                CarteiraMotorista = newMotorista.CarteiraMotorista
            };

            _context.Motoristas.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<IEnumerable<Motorista>> GetIncompleteItemsAsync()
        {
            var motoristas = await _context.Motoristas
                .ToArrayAsync();

            return motoristas;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var motoristas = await _context.Motoristas
                .Where(x => x.IdMotorista == id)
                .SingleOrDefaultAsync();

            if (motoristas == null)
                return false;

            motoristas.IsDone = true;

            var saveResult = await _context
                .SaveChangesAsync();

            // One entity should
            // have been updated
            return saveResult == 1;
        }
    }
}
