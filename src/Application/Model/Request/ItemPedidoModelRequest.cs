using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.Response;

namespace Application.Model.Request
{
    public class ItemPedidoModelRequest
    {
        public long IdPedido { get; set; }
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
