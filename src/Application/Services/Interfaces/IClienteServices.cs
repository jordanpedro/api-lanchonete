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
    public interface IClienteServices
    {
        Task<bool> InsertAsync(ClienteModelRequest cliente);
        Task<List<ClienteModelResponse>> GetAllAsync();
        Task<ClienteModelResponse> GetAsync(long id);
        Task<ClienteModelResponse> GetByCpfAsync(string cpf);        
        Task<bool> UpdateAsync(ClienteModelRequest cliente, long idcliente);
        Task<bool> DeleteAsync(long id);
    }
}
