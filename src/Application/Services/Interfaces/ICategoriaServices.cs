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
        Task<bool> InsertAsync(Categoria categoria);
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria> GetAsync(long id);
        Task<bool> UpdateAsync(Categoria categoria);
        Task<bool> DeleteAsync(long id);
    }
}
