using IFS.DB.Application.Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IFS.DB.Application.Domain.Attributes
{
    public class APIFromHeaderAttribute : FromHeaderAttribute
    {
        public bool Required { get; set; } = false;
    }

    public class IdempotencyKeyHeaderAttribute : APIFromHeaderAttribute
    {
        public IdempotencyKeyHeaderAttribute()
        {
            Name = APIConstant.Header.x_idempotency_key;
        }
    }
}
