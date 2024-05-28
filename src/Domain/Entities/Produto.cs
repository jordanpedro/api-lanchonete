using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string? Nome { get; set; }
        public Categoria? Categoria { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
