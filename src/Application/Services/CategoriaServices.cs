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
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaServices(ICategoriaRepository categoriaRepository) => _categoriaRepository = categoriaRepository;
        public async Task<bool> DeleteAsync(long id) => await _categoriaRepository.DeleteAsync(id);
        public async Task<List<CategoriaModelResponse>> GetAllAsync()
        {
            List<CategoriaModelResponse> listaRetorno = new List<CategoriaModelResponse>();

           var list =  await _categoriaRepository.GetAllAsync();

            if (list is not null && list.Count > 0) 
            {
                foreach (var item in list)
                {
                    listaRetorno.Add(new CategoriaModelResponse() { DataCriacao = item.DataCriacao, Id = item.Id, Nome = item.Nome });
                }
            }
            return listaRetorno;
        }
        public async Task<CategoriaModelResponse> GetAsync(long id)
        {
            var categoria =  await _categoriaRepository.GetAsync(id);
            
            if (categoria is not null && categoria.Id > 0)
            {
                return new CategoriaModelResponse() { Id = categoria.Id, Nome = categoria.Nome, DataCriacao = categoria.DataCriacao };
            }
            else
                return new();  
        }
        public async Task<bool> InsertAsync(CategoriaModelRequest categoriaRequest) => await _categoriaRepository.InsertAsync(CategoriaModelRequest.FromRequestToEntity(categoriaRequest));
        public async Task<bool> UpdateAsync(CategoriaModelRequest categoria, long idcategoria) => await _categoriaRepository.UpdateAsync(CategoriaModelRequest.FromRequestToEntity(categoria, idcategoria));
    }
}
