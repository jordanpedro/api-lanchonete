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
    public class ClienteMapper : ClassMapper<ClienteModel>
    {
        public ClienteMapper()
        {
            Table("Cliente");

            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.Nome).Column("Nome");
            Map(x => x.Cpf).Column("Cpf");
            Map(x => x.Email).Column("Email");
            Map(x => x.DataCriacao).Column("DataCriacao").ReadOnly();
        }
    }
}
