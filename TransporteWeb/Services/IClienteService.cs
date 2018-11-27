using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteWeb.Models;

namespace TransporteWeb.Services
{
    interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(NewCliente newCliente);
        Task<bool> MarkDoneAsync(Guid id);
    }
}
