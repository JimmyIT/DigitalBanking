using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Countries.GetAML
{
    public class GetAMLCountriesResponse
    {
        public string CountryCode { get; set; }
        public string CountryDesc { get; set; }
    }
}
