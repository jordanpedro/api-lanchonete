using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public abstract class ResultStatus
    {
        public bool Sucesso { get; set; }
    }

    public class Result<T> : ResultStatus
    {
        public Result()
        {
        }
        public Result(T resposta) : base()
        {
            Resposta = resposta;
        }

        public string? CodigoErro { get; set; }
        public string? Mensagem { get; set; }
        public T? Resposta { get; set; }
    }
}
