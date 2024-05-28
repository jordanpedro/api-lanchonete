using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class ItemPedidoModel : BaseModel
    {
        public long IdPedido { get; set; }
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }
        public static ItemPedidoModel FromEntityToModel(ItemPedido entity)
        {
            if (entity != null && entity?.Pedido?.Id > 0 && entity?.Produto?.Id > 0)
            {
                return new ItemPedidoModel { IdPedido = entity.Pedido.Id, IdProduto = entity.Produto.Id, Quantidade = entity.Quantidade };
            }
            else
                return new();
        }
    }
}
