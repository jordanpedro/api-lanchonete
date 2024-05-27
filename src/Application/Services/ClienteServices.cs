using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(IClienteRepository clienteRepository) => _clienteRepository = clienteRepository;
        public async Task<bool> DeleteAsync(long id) => await _clienteRepository.DeleteAsync(id);
        public async Task<List<Cliente>> GetAllAsync() => await _clienteRepository.GetAllAsync();
        public async Task<Cliente> GetAsync(long id) => await _clienteRepository.GetAsync(id);
        public async Task<Cliente> GetByCpfAsync(string cpf)  => await _clienteRepository.GetByCpfAsync(cpf);
        public async Task<bool> InsertAsync(Cliente cliente) => await _clienteRepository.InsertAsync(cliente);
        public async Task<bool> UpdateAsync(Cliente cliente) => await _clienteRepository.UpdateAsync(cliente);
    }
}
