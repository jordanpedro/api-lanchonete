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
    public class ProdutoMapper : ClassMapper<ProdutoModel>
    {
        public ProdutoMapper()
        {
            Table("Produto");

            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.Nome).Column("Nome");
            Map(x => x.IdCategoria).Column("IdCategoria");
            Map(x => x.ImagemUrl).Column("ImagemUrl");
            Map(x => x.Preco).Column("Preco");
            Map(x => x.DataCriacao).Column("DataCriacao").ReadOnly();
        }
    }
}
