using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class PedidoAgreggateModel : BaseModel
    {
        public PedidoAgreggateModel()
        {
        }
        public string? Status { get; set; }
        public long? IdCliente { get; set; }
        public decimal ValorTotal{ get; set; }
        public static PedidoAgreggateModel FromEntityToModelInInsert(PedidoAgreggate entity)
        {
            if (entity != null)
            {
                long? idCliente = entity.Cliente?.Id is not null && entity.Cliente?.Id > 0 ? entity.Cliente.Id : null;
                return new PedidoAgreggateModel { IdCliente = idCliente, DataCriacao = entity.DataCriacao, ValorTotal = entity.ValorTotal, Status = StatusPedido.Recebido.ToString().ToLower() };
            }
            else
                return new();
        }
    }
}
