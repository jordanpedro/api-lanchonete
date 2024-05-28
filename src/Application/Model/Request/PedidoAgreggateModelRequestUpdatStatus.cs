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
    public class PedidoAgreggateModelRequestUpdatStatus
    {
        public long Id { get; set; }
        public string? Status { get; set; }
        public PedidoAgreggateModelRequestUpdatStatus()
        {
        }
        public static PedidoAgreggate FromRequestToEntity(PedidoAgreggateModelRequestUpdatStatus request, long id)
        {
            var entity = new PedidoAgreggate()
            {
                Id = id,
                Status = request.Status,
            };
            return entity;
        }
    }
}
