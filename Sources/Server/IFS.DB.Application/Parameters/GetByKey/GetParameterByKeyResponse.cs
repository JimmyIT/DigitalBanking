using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Parameters.GetByKey
{
    public class GetParameterByKeyResponse
    {
        public string ParameKey { get; set; }
        public object ParamValue { get; set; }
    }
}
