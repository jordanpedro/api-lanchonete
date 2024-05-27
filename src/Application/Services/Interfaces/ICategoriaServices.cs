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
    public interface ICategoriaServices
    {
        Task<bool> InsertAsync(CategoriaModelRequest categoria);
        Task<List<CategoriaModelResponse>> GetAllAsync();
        Task<CategoriaModelResponse> GetAsync(long id);
        Task<bool> UpdateAsync(CategoriaModelRequest categoria, long idcategoria);
        Task<bool> DeleteAsync(long id);
    }
}
