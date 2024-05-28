using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLanchonete.Model.Response
{
    public class CategoriaModelResponse : BaseModelResponse
    {
        public DateTime? DataCriacao { get; set; }
        public string? Nome { get; set; }
    }
}
