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
    public class PedidoAgreggateModelRequest 
    {
        public PedidoAgreggateModelRequest()
        {
            ItensPedido = new List<ItemPedidoModelRequest>();
        }
        public string? Cpf { get; set; }
        public List<ItemPedidoModelRequest> ItensPedido { get; set; }
        public static PedidoAgreggate FromRequestToEntity(PedidoAgreggateModelRequest request, Cliente cliente, decimal valor)
        {
            var entity = new PedidoAgreggate()
            {
                Cliente = new Cliente()
                {
                    Cpf = cliente.Cpf,
                    Id = cliente.Id,
                    DataCriacao = cliente.DataCriacao,
                    Email = cliente.Email,
                    Nome = cliente.Nome
                },
                ValorTotal = valor
            };

            if (request?.ItensPedido?.Count > 0)
            {
                foreach (var item in request.ItensPedido)
                    entity.ItensPedido!.Add(new ItemPedido() { Produto = new Produto() { Id = item.IdProduto }, Quantidade = item.Quantidade });
            }
            return entity;
        }
    }
}
