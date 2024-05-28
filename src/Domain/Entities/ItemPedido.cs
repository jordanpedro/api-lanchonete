using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        public PedidoAgreggate? Pedido { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
