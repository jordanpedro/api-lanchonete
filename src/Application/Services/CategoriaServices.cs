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
        public async Task<List<Categoria>> GetAllAsync() => await _categoriaRepository.GetAllAsync();
        public async Task<Categoria> GetAsync(long id) => await _categoriaRepository.GetAsync(id);
        public async Task<bool> InsertAsync(Categoria categoria) => await _categoriaRepository.InsertAsync(categoria);
        public async Task<bool> UpdateAsync(Categoria categoria) => await _categoriaRepository.UpdateAsync(categoria);
    }
}
