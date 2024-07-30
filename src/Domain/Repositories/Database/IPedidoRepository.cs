using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Database
{
    public interface IPedidoRepository : IBaseRepository<PedidoAgreggate>
    {
        Task<bool> UpdateStatusAsync(PedidoAgreggate pedido); 
        Task<List<PedidoAgreggate>> GetByStatusAsync(string status);
        Task<List<PedidoAgreggate>> GetAllAsync();
        Task<long> InsertWithReturnIdAsync(PedidoAgreggate entity);
       Task<long> InsertItensAsync(ItemPedido entity);
    }
}
