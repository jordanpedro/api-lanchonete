using ApiLanchonete.Model.Response;
using Application.Model.Request;
using Application.Model.Response;
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
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoServices(IProdutoRepository produtoRepository) => _produtoRepository = produtoRepository;
        public async Task<bool> DeleteAsync(long id) => await _produtoRepository.DeleteAsync(id);
        public async Task<List<ProdutoModelResponse>> GetAllAsync()
        {
            List<ProdutoModelResponse> listaRetorno = new List<ProdutoModelResponse>();

            var list = await _produtoRepository.GetAllAsync();

            if (list is not null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    listaRetorno.Add(new ProdutoModelResponse() { DataCriacao = item.DataCriacao, Id = item.Id, Nome = item.Nome, Preco = item.Preco, ImagemUrl = item.ImagemUrl, IdCategoria = item.Categoria!.Id });
                }
            }
            return listaRetorno;
        }
        public async Task<List<ProdutoModelResponse>> GetByIdCategoriaAsync(long id)
        {
            List<ProdutoModelResponse> listaRetorno = new List<ProdutoModelResponse>();

            var list = await _produtoRepository.GetByIdCategoriaAsync(id);
            if (list is not null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (item.Id > 0 && item?.Categoria?.Id > 0)
                    listaRetorno.Add(new ProdutoModelResponse() { DataCriacao = item.DataCriacao, Id = item.Id, Nome = item.Nome, Preco = item.Preco, ImagemUrl = item.ImagemUrl, IdCategoria = item.Categoria!.Id });
                }
            }
            return listaRetorno;
        }
        public async Task<ProdutoModelResponse> GetAsync(long id)
        {
             var entity = await _produtoRepository.GetAsync(id);

            if (entity is not null && entity.Id > 0)
            {
                return new ProdutoModelResponse() { Id = entity.Id, Nome = entity.Nome, DataCriacao = entity.DataCriacao, Preco = entity.Preco, ImagemUrl = entity.ImagemUrl, IdCategoria = entity.Categoria!.Id };
            }
            else
                return new();
        }
        public async Task<bool> InsertAsync(ProdutoModelRequest produto) => await _produtoRepository.InsertAsync(ProdutoModelRequest.FromRequestToEntity(produto));
        public async Task<bool> UpdateAsync(ProdutoModelRequest produto, long id) => await _produtoRepository.UpdateAsync(ProdutoModelRequest.FromRequestToEntity(produto, id));
    }
}
