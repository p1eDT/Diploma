using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.Api.RestEntities
{
    public class CommonResultResponse<T>
    {
        public bool Status { get; set; }
        public T Result { get; set; }
    }
}
