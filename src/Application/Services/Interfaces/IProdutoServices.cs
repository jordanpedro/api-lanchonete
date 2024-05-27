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
    public interface IProdutoServices
    {
        Task<bool> InsertAsync(ProdutoModelRequest produto);
        Task<List<ProdutoModelResponse>> GetAllAsync();
        Task<ProdutoModelResponse> GetAsync(long id);
        Task<List<ProdutoModelResponse>> GetByIdCategoriaAsync(long id);
        Task<bool> UpdateAsync(ProdutoModelRequest produto, long id);
        Task<bool> DeleteAsync(long id);
    }
}
