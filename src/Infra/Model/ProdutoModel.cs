using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class ProdutoModel : BaseModel
    {
        public string? Nome { get; set; }
        public long IdCategoria { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public static ProdutoModel FromEntityToModel(Produto entity)
        {
            if (entity != null)
                return new ProdutoModel { Nome = entity.Nome, DataCriacao = entity.DataCriacao, Id = entity.Id, IdCategoria = entity.Categoria!.Id, ImagemUrl = entity.ImagemUrl, Preco = entity.Preco };
            else
                return new();
        }
        public static Produto FromModelToEntity(ProdutoModel entity)
        {
            if (entity != null)
                return new Produto { Nome = entity.Nome, DataCriacao = entity.DataCriacao, Id = entity.Id, Categoria = new Categoria() { Id = entity.IdCategoria }, Preco = entity.Preco, ImagemUrl = entity.ImagemUrl };
            else
                return new();
        }
    }
}
