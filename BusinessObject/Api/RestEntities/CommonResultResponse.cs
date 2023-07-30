using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Api.RestEntities
{
    public class CommonResultResponse<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
