using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class PedidoFormaPagamentoModel : BaseModel
    {
        public string? Status { get; set; }
        public long IdPedido { get; set; }
        public long IdFormaPagamento { get; set; }
        public static PedidoFormaPagamentoModel FromEntityToModelInInsert(PedidoFormaPagamento entity)
        {
            if (entity != null)
            {
                long idFormaPagamento = entity.FormaPagamento?.Id is not null && entity.FormaPagamento?.Id > 0 ? entity.FormaPagamento.Id : 0;
                long idPedido = entity.Pedido?.Id is not null && entity.Pedido?.Id > 0 ? entity.Pedido.Id : 0;
                return new PedidoFormaPagamentoModel { IdPedido = idPedido, IdFormaPagamento = idFormaPagamento, Status = entity.Status };
            }
            else
                return new();
        }
    }
}
