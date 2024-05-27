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
    public class CategoriaMapper : ClassMapper<CategoriaModel>
    {
        public CategoriaMapper()
        {
            Table("Categoria");

            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.Nome).Column("Nome");
            Map(x => x.DataCriacao).Column("DataCriacao").ReadOnly();
        }
    }
}
