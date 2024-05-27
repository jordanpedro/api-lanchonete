using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Pedido
{
    public class PedidoAgreggateSumario
    {
        public int IdPedido { get; set; }
        public string Status { get; set; }
        public string ValorTotal { get; set; }
        public List<ItemSumario> Itens { get; set; }

        public static PedidoAgreggateSumario PedidoFromTo(PedidoAgreggate pedido)
        {
            return new PedidoAgreggateSumario()
            {

            };
        }
    }
    public record ItemSumario (string Nome, string ImagemUrl, int quantidade);
}
