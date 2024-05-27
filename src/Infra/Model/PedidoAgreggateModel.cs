using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class PedidoAgreggateModel : BaseModel
    {
        public PedidoAgreggateModel()
        {
            ItensPedido = new List<ItemPedidoModel>();
        }
        public string? Status { get; set; }
        public long? IdCliente { get; set; }
        public decimal ValorTotal{ get; set; }     
        public List<ItemPedidoModel> ItensPedido { get; set; }
    }
}
