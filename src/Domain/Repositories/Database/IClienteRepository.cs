using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Database
{
    public interface IClienteRepository:  IBaseRepository<Cliente>
    {
        Task<Cliente> GetByCpfAsync(string cpf);
    }
}
