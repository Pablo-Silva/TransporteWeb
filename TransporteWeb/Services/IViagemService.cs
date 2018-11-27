using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteWeb.Models;

namespace TransporteWeb.Services
{
    interface IViagemService
    {
        Task<IEnumerable<Viagem>> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(NewViagem newViagem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}
