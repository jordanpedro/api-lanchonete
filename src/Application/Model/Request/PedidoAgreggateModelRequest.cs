using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.Response;

namespace Application.Model.Request
{
    public class PedidoAgreggateModelRequest 
    {
        public PedidoAgreggateModelRequest()
        {
            ItensPedido = new List<ItemPedidoModelRequest>();
        }
        public string? Status { get; set; }
        public long? IdCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ItemPedidoModelRequest> ItensPedido { get; set; }
    }
}
