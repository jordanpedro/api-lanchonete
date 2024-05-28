using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{

    public class ClienteModel: BaseModel
    {
        public string? Nome { get; set; }

        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public static ClienteModel FromEntityToModel(Cliente cliente)
        {
            if (cliente != null)
                return new ClienteModel { Nome = cliente.Nome, DataCriacao = cliente.DataCriacao, Id = cliente.Id, Cpf = cliente.Cpf, Email = cliente .Email};
            else
                return new();
        }
        public static Cliente FromModelToEntity(ClienteModel cliente)
        {
            if (cliente != null)
                return new Cliente { Nome = cliente.Nome, DataCriacao = cliente.DataCriacao, Id = cliente.Id, Cpf = cliente.Cpf, Email = cliente.Email };
            else
                return new();
        }
    }
}
