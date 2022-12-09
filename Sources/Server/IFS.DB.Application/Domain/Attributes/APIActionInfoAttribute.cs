using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Attributes
{
    public class APIActionInfoAttribute : Attribute
    {
        public string MessageCode { get; set; }
        public string MessageDescription { get; set; }

        public APIActionInfoAttribute(string messageCode, string messageDescription)
        {
            MessageCode = messageCode;
            MessageDescription = messageDescription;
        }
    }
}
