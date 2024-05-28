using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class QuantidadeDeProdutoInvalidaException : Exception
    {
        public QuantidadeDeProdutoInvalidaException(string message) : base(message) 
        {
            
        }
    }
}
