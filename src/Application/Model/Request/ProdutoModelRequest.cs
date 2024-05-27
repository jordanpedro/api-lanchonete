using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.Response;

namespace Application.Model.Request
{
    public class ProdutoModelRequest
    {
        public string? Nome { get; set; }
        public long IdCategoria { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
