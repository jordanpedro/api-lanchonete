using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.Response;
using Domain.Entities;

namespace Application.Model.Request
{
    public class ProdutoModelRequest
    {
        public string? Nome { get; set; }
        public long IdCategoria { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }

        public static Produto FromRequestToEntity(ProdutoModelRequest request)
        {
            var entity = new Produto()
            {
                Nome = request.Nome,
                Preco = request.Preco,
                ImagemUrl = request.ImagemUrl,
                Categoria = new Categoria() { Id = request.IdCategoria }
            };
            return entity;
        }
        public static Produto FromRequestToEntity(ProdutoModelRequest request, long id)
        {
            var entity = new Produto()
            {
                Nome = request.Nome,
                Preco = request.Preco,
                ImagemUrl = request.ImagemUrl,
                Categoria = new Categoria() { Id = request.IdCategoria },
                Id = id
            };

            return entity;
        }
    }
}
