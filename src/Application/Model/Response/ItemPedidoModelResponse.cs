using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLanchonete.Model.Response
{
    public class ItemPedidoModelResponse
    {
        public string? NomeProduto { get; set; }
        public string? CategoriaProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
