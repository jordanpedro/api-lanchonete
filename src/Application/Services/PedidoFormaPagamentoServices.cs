using ApiLanchonete.Model.Response;

using Application.Exceptions;
using Application.Model.Request;
using Application.Model.Response;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Application.Services
{
    public class PedidoFormaPagamentoServices : IPedidoFormaPagamentoServices
    {
        private readonly IPedidoFormaPagamentoRepository _pedidoFormaPagamentoRepository;
        public PedidoFormaPagamentoServices(IPedidoFormaPagamentoRepository pedidoRepository)
        {
            _pedidoFormaPagamentoRepository = pedidoRepository;
        }
        public async Task<PedidoFormaPagamentoResponse> GetAsync(long id)
        {
            var entity = await _pedidoFormaPagamentoRepository.GetAsync(id);

            if (entity is not null && entity.Id > 0)
            {
                return PedidoFormaPagamentoResponse.FromEntityToResponse(entity);
            }
            else
                return new();
        }
        public async Task<bool> InsertAsync(PedidoFormaPagamentoModelRequest pedido) => await _pedidoFormaPagamentoRepository.InsertAsync(PedidoFormaPagamentoModelRequest.FromRequestToEntity(pedido));
        
    }
}
