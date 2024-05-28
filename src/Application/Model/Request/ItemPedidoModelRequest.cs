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
    public class ItemPedidoModelRequest
    {
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }
        public static ItemPedido FromRequestToEntity(ItemPedidoModelRequest request, long idPedido)
        {
            var entity = new ItemPedido()
            {
              Pedido = new PedidoAgreggate()
              {
                  Id = idPedido
              },
              Produto = new Produto() { Id = request.IdProduto },
              Quantidade = request.Quantidade
            };

            return entity;
        }
    }
}
