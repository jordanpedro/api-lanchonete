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
    public class PedidoFormaPagamentoMapper : ClassMapper<PedidoFormaPagamentoModel>
    {
        public PedidoFormaPagamentoMapper()
        {
            Table("PedidoFormaPagamento");
            
            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.IdPedido).Column("IdPedido");
            Map(x => x.IdFormaPagamento).Column("IdFormaPagamento");
            Map(x => x.Status).Column("Status");
        }
    }
}
