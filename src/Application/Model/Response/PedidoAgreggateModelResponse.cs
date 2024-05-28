using Application.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLanchonete.Model.Response
{
    public class PedidoAgreggateModelResponse : BaseModelResponse
    {
        public PedidoAgreggateModelResponse()
        {
            ItensPedido = new List<ItemPedidoModelResponse>();
        }
        public string? Status { get; set; }
        public string? NomeCliente { get; set; }
        public decimal ValorTotal{ get; set; }
        public DateTime? DataCriacao { get; set; }
        public List<ItemPedidoModelResponse> ItensPedido { get; set; } = new List<ItemPedidoModelResponse>();

        public static PedidoAgreggateModelResponse FromEntityToResponse(PedidoAgreggate entity)
        {
            PedidoAgreggateModelResponse response = new PedidoAgreggateModelResponse()
            {
                 DataCriacao = entity.DataCriacao ,
                 ValorTotal = entity.ValorTotal ,
                 Status = entity.Status ,
                 Id = entity.Id ,
                 NomeCliente = entity?.Cliente?.Nome                 
            };

            foreach ( var item in entity.ItensPedido!)
            {
                response.ItensPedido.Add(new ItemPedidoModelResponse() { NomeProduto = item?.Produto?.Nome, CategoriaProduto = item?.Produto?.Categoria?.Nome, Quantidade = item!.Quantidade });
            }
            return response;
        }
    }
}
