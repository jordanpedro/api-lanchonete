using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class CategoriaModel : BaseModel
    {
        public string? Nome { get; set; }

        public static CategoriaModel FromEntityToModel(Categoria categoria)
        {
            if (categoria != null)
                return new CategoriaModel { Nome = categoria.Nome, DataCriacao = categoria.DataCriacao, Id = categoria.Id };
            else
                return new();
        }
        public static Categoria FromModelToEntity(CategoriaModel categoria)
        {
            if (categoria != null)
                return new Categoria { Nome = categoria.Nome, DataCriacao = categoria.DataCriacao, Id = categoria.Id };
            else
                return new();
        }

    }
}
