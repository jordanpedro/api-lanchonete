using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Model.Request
{
    public class PedidoFormaPagamentoModelRequest
    {
        public long IdPedido { get; set; }
        public long IdFormaPagamento { get; set; }
        public string? Status { get; set; }

        public static PedidoFormaPagamento FromRequestToEntity(PedidoFormaPagamentoModelRequest request)
        {
            var entity = new PedidoFormaPagamento()
            {
                FormaPagamento = new FormaPagamento { Id = request.IdFormaPagamento },
                Status = request.Status,
                Pedido = new PedidoAgreggate() { Id = request.IdPedido }
            };
            return entity;
        }
        public static PedidoFormaPagamento FromRequestToEntity(PedidoFormaPagamentoModelRequest request, long id)
        {
            var entity = new PedidoFormaPagamento()
            {
                Id = id,
                FormaPagamento = new FormaPagamento { Id = request.IdFormaPagamento },
                Status = request.Status,
                Pedido = new PedidoAgreggate() { Id = request.IdPedido }
            };
            return entity;
        }
    }
}
