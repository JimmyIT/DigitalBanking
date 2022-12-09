using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Client.Enums
{
    public enum AMLCustomerStatusEnum
    {
        Unknown = 0,
        Approved = 1,
        Rejected = 2,
        Pending = 3
    }

    public enum EmploymentStatusEnum
    {
        NotAvailable = 0,
        FullTime = 1,
        PartTime = 2,
        Unemployed = 3,
        Pensioner = 4,
        SelfEmployed = 5,
        None = 6
    }

    public enum AMLTracEntityType
    {
        Individual = 11,
    }
}
