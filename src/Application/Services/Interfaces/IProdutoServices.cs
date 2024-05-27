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
        Task<bool> InsertAsync(Produto produto);
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetAsync(long id);
        Task<List<Produto>> GetByIdCategoriaAsync(long id);
        Task<bool> UpdateAsync(Produto produto);
        Task<bool> DeleteAsync(long id);
    }
}
