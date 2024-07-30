using ApiLanchonete.Model.Response;
using Application.Model.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPedidoServices
    {
        Task<long> InsertAsync(PedidoAgreggateModelRequest pedido);
        Task<PedidoAgreggateModelResponse> GetAsync(long id);
        Task<bool> UpdateStatusAsync(PedidoAgreggateModelRequestUpdatStatus pedido, long id);
        Task<List<PedidoAgreggateModelResponse>> GetByStatusAsync(string status);
        Task<List<PedidoAgreggateModelResponse>> GetAllAsync();

    }
}
