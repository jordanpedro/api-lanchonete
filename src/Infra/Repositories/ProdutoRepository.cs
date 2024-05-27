using Dapper;
using DapperExtensions;
using Domain.Entities;
using Domain.Repositories.Database;
using Infra.Model;
using Infra.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDatabaseConnectionFactory databaseConnectionFactory) : base(databaseConnectionFactory)
        {
        }
        public override async Task<List<Produto>> GetAllAsync()
        {
            List<Produto> listaEntity = new List<Produto>();
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IEnumerable<ProdutoModel>? list = await conn.GetListAsync<ProdutoModel>();
            conn.Close();

            if (list != null && list.Any())
            {
                foreach (var item in list)
                    listaEntity.Add(ProdutoModel.FromModelToEntity(item));
            }
            return listaEntity?.AsList() ?? new List<Produto>();
        }
        public override async Task<Produto> GetAsync(long id)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            ProdutoModel? entityModel = await conn.GetAsync<ProdutoModel>(id);
            conn.Close();
            var ret = ProdutoModel.FromModelToEntity(entityModel);
            return ret ?? new();
        }

        public async Task<List<Produto>> GetByIdCategoriaAsync(long id)
        {
            List <Produto> listaProdutos = new List<Produto> ();
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IEnumerable<ProdutoModel>? list = await conn.QueryAsync<ProdutoModel>($"SELECT * FROM Produto WHERE IdCategoria = {id}"); 
            conn.Close();

            if ( list != null && list.Any())
            {
                foreach(var item in list)
                {
                    listaProdutos.Add(ProdutoModel.FromModelToEntity(item));
                }
            }
            return listaProdutos ?? new List<Produto>();
        }
        public override async Task<bool> InsertAsync(Produto entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = ProdutoModel.FromEntityToModel(entity);
            var id = await conn.InsertAsync(model);
            conn.Close();
            return id > 0;
        }
        public override async Task<bool> UpdateAsync(Produto entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = ProdutoModel.FromEntityToModel(entity);
            var retorno = await conn.UpdateAsync(model);
            conn.Close();
            return retorno;
        }
    }
}
