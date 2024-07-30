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
    public class FormaPagamentoModelRequest
    {
        public long Id { get; set; }

        public static FormaPagamento FromRequestToEntity(FormaPagamentoModelRequest request)
        {
            var entity = new FormaPagamento()
            {
                Id = request.Id                
            };
            return entity;
        }
        public static FormaPagamento FromRequestToEntity(FormaPagamentoModelRequest request, long id)
        {
            var entity = new FormaPagamento()
            {
                Id = request.Id,
            };
            return entity;
        }
    }
}
