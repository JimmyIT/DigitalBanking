using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Parameters.GetByKey
{
    public class GetParameterByKeyResponse
    {
        public string ParameKey { get; set; }
        public object ParamValue { get; set; }
    }
}
