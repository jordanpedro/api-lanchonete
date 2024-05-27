using ApiLanchonete.Model.Response;
using Application.Model.Request;
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
        public async Task<List<ClienteModelResponse>> GetAllAsync()
        {
            List<ClienteModelResponse> listaRetorno = new List<ClienteModelResponse>();

            var list = await _clienteRepository.GetAllAsync();

            if (list is not null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    listaRetorno.Add(new ClienteModelResponse() { DataCriacao = item.DataCriacao, Id = item.Id, Nome = item.Nome });
                }
            }
            return listaRetorno;
        }
        public async Task<ClienteModelResponse> GetAsync(long id)
        {
            var entity = await _clienteRepository.GetAsync(id);

            if (entity is not null && entity.Id > 0)
            {
                return new ClienteModelResponse() { Id = entity.Id, Nome = entity.Nome, DataCriacao = entity.DataCriacao, Cpf = entity.Cpf, Email = entity.Cpf };
            }
            else
                return new();
        }
        public async Task<ClienteModelResponse> GetByCpfAsync(string cpf)
        {
            var entity = await _clienteRepository.GetByCpfAsync(cpf);

            if (entity is not null && entity.Id > 0)
            {
                return new ClienteModelResponse() { Id = entity.Id, Nome = entity.Nome, DataCriacao = entity.DataCriacao, Cpf = entity.Cpf, Email = entity.Cpf };
            }
            else
                return new();
        }
        public async Task<bool> InsertAsync(ClienteModelRequest cliente) => await _clienteRepository.InsertAsync(ClienteModelRequest.FromRequestToEntity(cliente));
        public async Task<bool> UpdateAsync(ClienteModelRequest cliente, long idcliente) => await _clienteRepository.UpdateAsync(ClienteModelRequest.FromRequestToEntity(cliente, idcliente));
    }
}
