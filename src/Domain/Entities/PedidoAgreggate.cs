using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PedidoAgreggate : BaseEntity
    {
        public PedidoAgreggate()
        {
            ItensPedido = new List<ItemPedido>();
        }
        public string? Status { get; set; }
        public long? IdCliente { get; set; }
        public decimal ValorTotal{ get; set; }     
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
