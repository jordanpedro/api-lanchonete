using ApiLanchonete.Model.Response;
using Application.Model.Request;
using Application.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPedidoFormaPagamentoServices
    {
        Task<bool> InsertAsync(PedidoFormaPagamentoModelRequest pedido);
        Task<PedidoFormaPagamentoResponse> GetAsync(long id);        
    }
}
