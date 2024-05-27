using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PedidoServices : IPedidoServices
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoServices(IPedidoRepository pedidoRepository) => _pedidoRepository = pedidoRepository;
        public async Task<PedidoAgreggate> GetAsync(long id) => await _pedidoRepository.GetAsync(id);
        public async Task<bool> InsertAsync(PedidoAgreggate pedido) => await _pedidoRepository.InsertAsync(pedido);
        public async Task<bool> UpdateStatusAsync(PedidoAgreggate pedido) => await _pedidoRepository.UpdateStatusAsync(pedido);
        public async Task<List<PedidoAgreggate>> GetByStatusAsync(string status) => await _pedidoRepository.GetByStatusAsync(status);
        
    }
}
