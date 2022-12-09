using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Results
{
    public class ActionResult<T>
    {
        public bool IsNotFound { get; set; }
        public bool IsNotError { get => Validation?.IsValid != false; }
        public ValidationResult Validation { get; set; }
        public T Result { get; set; }
    }
}
