using ApiLanchonete.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response
{
    public class PedidoFormaPagamentoResponse 
    {
        public string? Status { get; set; }
        public long IdPedido { get; set; }
        public long IdFormaPagamento { get; set; }

        public static PedidoFormaPagamentoResponse FromEntityToResponse(PedidoFormaPagamento entity)
        {
            PedidoFormaPagamentoResponse response = new PedidoFormaPagamentoResponse()
            {
                Status = entity.Status,                
                IdFormaPagamento = entity?.FormaPagamento?.Id ?? 0,
                IdPedido = entity?.Pedido?.Id ?? 0,
            };

            return response;
        }
    }
}
