using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PedidoFormaPagamento : BaseEntity
    {
        public FormaPagamento? FormaPagamento { get; set; }
        public PedidoAgreggate? Pedido { get; set; }
        public string? Status { get; set; }
    }
}
