using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteWeb.Models;

namespace TransporteWeb.Services
{
    interface IMotoristaService
    {
        Task<IEnumerable<Motorista>> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(NewMotorista newMotorista);
        Task<bool> MarkDoneAsync(Guid id);
    }
}
