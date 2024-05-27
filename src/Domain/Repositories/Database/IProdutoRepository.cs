﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Database
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<List<Produto>> GetByIdCategoriaAsync(long id);
    }
}
