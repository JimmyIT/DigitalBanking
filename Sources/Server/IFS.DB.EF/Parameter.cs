using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Parameter
    {
        public string ParamKey { get; set; } = null!;
        public string ParamValue { get; set; } = null!;
        public string ParamDescription { get; set; } = null!;
        public bool? UserEditable { get; set; }
        public string ParameterType { get; set; } = null!;
    }
}
