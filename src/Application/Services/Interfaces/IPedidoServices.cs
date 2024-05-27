using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPedidoServices
    {
        Task<bool> InsertAsync(PedidoAgreggate pedido);
        Task<PedidoAgreggate> GetAsync(long id);
        Task<bool> UpdateStatusAsync(PedidoAgreggate pedido);
        Task<List<PedidoAgreggate>> GetByStatusAsync(string status);
        
    }
}
