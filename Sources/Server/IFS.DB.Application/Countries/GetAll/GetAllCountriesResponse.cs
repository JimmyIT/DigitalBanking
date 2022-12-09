using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Countries.GetAll
{
    public class GetAllCountriesResponse
    {
        public string CountryCode { get; set; }
        public int? DialingCode { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public string IDDCode { get; set; }
        public string NationalPrefix { get; set; }

        public static void ConfigMapping()
        {
            TypeAdapterConfig<CountryCode, GetAllCountriesResponse>
                .NewConfig()
                .Map(dst => dst.CountryCode, src => src.CountryCode1)
                ;
        }
    }
}
