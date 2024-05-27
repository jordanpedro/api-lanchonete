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
        Task<bool> InsertAsync(Cliente cliente);
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetAsync(long id);
        Task<Cliente> GetByCpfAsync(string cpf);        
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(long id);
    }
}
