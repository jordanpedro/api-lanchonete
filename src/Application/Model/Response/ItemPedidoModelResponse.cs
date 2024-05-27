using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLanchonete.Model.Response
{
    public class ItemPedidoModelResponse : BaseModelResponse
    {
        public long IdPedido { get; set; }
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
