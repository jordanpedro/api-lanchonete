using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLanchonete.Model.Response
{
    public class PedidoAgreggateModelResponse : BaseModelResponse
    {
        public PedidoAgreggateModelResponse()
        {
            ItensPedido = new List<ItemPedidoModelResponse>();
        }
        public string? Status { get; set; }
        public long? IdCliente { get; set; }
        public decimal ValorTotal{ get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ItemPedidoModelResponse> ItensPedido { get; set; }
    }
}
