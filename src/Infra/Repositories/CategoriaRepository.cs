using Dapper;
using DapperExtensions;
using Domain.Entities;
using Domain.Repositories.Database;
using Infra.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IDatabaseConnectionFactory databaseConnectionFactory) : base(databaseConnectionFactory)
        {
        }
        public override async Task<bool> InsertAsync(Categoria entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = CategoriaModel.FromEntityToModel(entity);
            var id = await conn.InsertAsync(model);
            conn.Close();
            return id > 0;
        }
        public override async Task<bool> UpdateAsync(Categoria entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = CategoriaModel.FromEntityToModel(entity);
            var retorno = await conn.UpdateAsync(model);
            conn.Close();
            return retorno;
        }
        public override async Task<List<Categoria>> GetAllAsync()
        {
            List <Categoria> listCategoria = new List<Categoria>();
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IEnumerable<CategoriaModel>? list = await conn.GetListAsync<CategoriaModel>();
            conn.Close();

            if (list != null && list.Any())
            {
                foreach (var item in list)
                    listCategoria.Add(CategoriaModel.FromModelToEntity(item));
            }
            return listCategoria?.AsList() ?? new List<Categoria>();
        }
        public override async Task<Categoria> GetAsync(long idcategoria)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            CategoriaModel? cat = await conn.GetAsync<CategoriaModel>(idcategoria);
            conn.Close();
            var ret = CategoriaModel.FromModelToEntity(cat);
            return ret ?? new();
        }

    }
}
