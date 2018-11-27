using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteWeb.Data;
using TransporteWeb.Models;

namespace TransporteWeb.Services
{
    public class ViagemService : IViagemService
    {
        private readonly ApplicationDbContext _context;

        public ViagemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(NewViagem newViagem)
        {
            var entity = new Viagem
            {
                IdViagem = Guid.NewGuid(),
                Motorista = newViagem.Motorista,
                Cliente = newViagem.Cliente,
                EnderecoChegada = newViagem.EnderecoChegada,
                EnderecoSaida = newViagem.EnderecoSaida
            };

            _context.Viagens.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<IEnumerable<Viagem>> GetIncompleteItemsAsync()
        {
            var viagens = await _context.Viagens
               .ToArrayAsync();

            return viagens;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var viagens = await _context.Viagens
                .Where(x => x.IdViagem == id)
                .SingleOrDefaultAsync();

            if (viagens == null)
                return false;

            viagens.IsDone = true;

            var saveResult = await _context
                .SaveChangesAsync();

            // One entity should
            // have been updated
            return saveResult == 1;
        }
    }
}
