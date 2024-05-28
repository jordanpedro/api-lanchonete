using DapperExtensions.Mapper;
using Domain.Entities;
using Infra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.MapperEntities
{
    public class ItemPedidoMapper : ClassMapper<ItemPedidoModel>
    {
        public ItemPedidoMapper()
        {
            Table("ItensPedido");

            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.Quantidade).Column("Quantidade");
            Map(x => x.IdProduto).Column("IdProduto");
            Map(x => x.IdPedido).Column("IdPedido");
        }
    }
}
