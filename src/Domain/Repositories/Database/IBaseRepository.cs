using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Database
{
    public interface IBaseRepository<T> where T : class, new()
    {
        Task<T> GetAsync(long id);
        Task<List<T>> GetAllAsync();    
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long id);
        Task<bool> InsertAsync(T entity);
    }
}
