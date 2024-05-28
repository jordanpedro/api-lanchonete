using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ClienteNaoEncontradoException : Exception
    {
        public ClienteNaoEncontradoException(string message) : base(message) 
        {
            
        }
    }
}
