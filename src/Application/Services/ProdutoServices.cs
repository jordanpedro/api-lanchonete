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
        public async Task<List<Produto>> GetAllAsync() => await _produtoRepository.GetAllAsync();
        public async Task<List<Produto>> GetByIdCategoriaAsync(long id) => await _produtoRepository.GetByIdCategoriaAsync(id);
        public async Task<Produto> GetAsync(long id) => await _produtoRepository.GetAsync(id);
        public async Task<bool> InsertAsync(Produto produto) => await _produtoRepository.InsertAsync(produto);
        public async Task<bool> UpdateAsync(Produto produto) => await _produtoRepository.UpdateAsync(produto);
    }
}
