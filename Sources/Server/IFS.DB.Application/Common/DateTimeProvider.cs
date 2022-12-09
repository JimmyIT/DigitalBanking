using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common
{
    public interface IDateTimeProvider
    {
        DateTime Now();
        DateTime Today();
        DateTime UtcNow();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime Today()
        {
            return DateTime.Today;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
