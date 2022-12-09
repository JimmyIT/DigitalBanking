using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class DatabaseValueAttribute : Attribute
    {
        public DatabaseValueAttribute(string value)
        {
            Value = value;
        }

        public DatabaseValueAttribute(int value)
        {
            Value = value.ToString();
        }

        public DatabaseValueAttribute(Guid value)
        {
            Value = value.ToString();
        }

        public string Value { get; }
    }
}
