using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dept.OpenAir.Api.Models
{
    public class GenericResult<T>
    {
        public Meta? Meta { get; set; }
        public T[] Results { get; set; } = Array.Empty<T>();
    }
}
