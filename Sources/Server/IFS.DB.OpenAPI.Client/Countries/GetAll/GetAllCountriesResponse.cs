using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Client.Countries.GetAll
{
    public class GetAllCountriesResponse
    {
        public string CountryCode { get; set; }
        public int? DialingCode { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public string IDDCode { get; set; }
        public string NationalPrefix { get; set; }

    }
}
