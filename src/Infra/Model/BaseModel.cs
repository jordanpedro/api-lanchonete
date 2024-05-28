using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
