using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Currencies.GetAML
{
    public class GetAMLCurrenciesResponse
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public int DecimalPlaces { get; set; }
        public bool DivideOrMultiply { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
