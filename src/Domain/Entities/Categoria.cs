using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string? Nome { get; set; }
        public List<Produto>? Produtos { get; set; }
    }
}
