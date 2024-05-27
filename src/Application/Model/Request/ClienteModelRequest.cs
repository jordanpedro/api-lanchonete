using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Model.Request
{

    public class ClienteModelRequest
    {
        public string? Nome { get; set; }

        public string? Cpf { get; set; }
        public string? Email { get; set; }

        public static Cliente FromRequestToEntity(ClienteModelRequest request)
        {
            var entity = new Cliente()
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Email = request.Email,
            };

            return entity;
        }
        public static Cliente FromRequestToEntity(ClienteModelRequest request, long idcliente)
        {
            var entity = new Cliente()
            {
                Nome = request.Nome,
                Id = idcliente,
                Cpf = request.Cpf,
                Email = request.Email,
            };

            return entity;
        }
    }
}
