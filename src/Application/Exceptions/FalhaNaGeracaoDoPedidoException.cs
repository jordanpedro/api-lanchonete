using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class FalhaNaGeracaoDoPedidoException : Exception
    {
        public FalhaNaGeracaoDoPedidoException(string message) : base(message) 
        {
            
        }
    }
}
