using System.Text.Json;

namespace IFS.DB.WebApp.Models;

public class CultureInfoModel
{
    public string CultureInfoCode { get; set; }
    public string Country { get; set; }
    public string TwoLetterCountryCode { get; set; }
    public string ThreeLetterCountryCode { get; set; }
    public string Language { get; set; }
    public string PhoneNumberIDD { get; set; }
}
