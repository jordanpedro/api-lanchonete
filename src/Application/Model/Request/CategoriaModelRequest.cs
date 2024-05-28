using Application.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Request
{
    public class CategoriaModelRequest
    {
        public string? Nome { get; set; }

        public static Categoria FromRequestToEntity(CategoriaModelRequest categoriaRequest)
        {
            var categoria = new Categoria()
            {
                Nome = categoriaRequest.Nome
            };

            return categoria;
        }
        public static Categoria FromRequestToEntity(CategoriaModelRequest categoriaRequest, long idcategoria)
        {
            var categoria = new Categoria()
            {
                Nome = categoriaRequest.Nome,
                Id = idcategoria
            };

            return categoria;
        }
    }
}
