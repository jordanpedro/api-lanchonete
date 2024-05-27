using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLanchonete.Model.Response
{

    public class ClienteModelResponse : BaseModelResponse
    {
        public string? Nome { get; set; }

        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
