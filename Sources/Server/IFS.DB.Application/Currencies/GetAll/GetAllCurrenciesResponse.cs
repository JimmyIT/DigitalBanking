using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Currencies.GetAll
{
    public class GetAllCurrenciesResponse
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public int DecimalPlaces { get; set; }
    }
}
