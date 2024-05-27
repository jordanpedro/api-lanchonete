using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class ItemPedidoModel : BaseModel
    {
        public long IdPedido { get; set; }
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
