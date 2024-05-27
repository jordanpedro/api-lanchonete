using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class ProdutoModel : BaseModel
    {
        public string? Nome { get; set; }
        public long IdCategoria { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
