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
    public class PedidoAggregateMapper : ClassMapper<PedidoAgreggateModel>
    {
        public PedidoAggregateMapper()
        {
            Table("Pedido");

            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.IdCliente).Column("IdCliente");
            Map(x => x.Status).Column("Status");
            Map(x => x.ValorTotal).Column("ValorTotal");
            Map(x => x.DataCriacao).Column("DataCriacao").ReadOnly();
        }
    }
}
