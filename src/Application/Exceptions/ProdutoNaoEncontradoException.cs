using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException(string message) : base(message) 
        {
            
        }
    }
}
