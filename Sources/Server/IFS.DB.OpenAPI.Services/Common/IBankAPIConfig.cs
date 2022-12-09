namespace IFS.DB.OpenAPI.Services.Common
{
    public class IBankAPIConfig
    {
        public const string CLIENT_NAME = "IBANK_CLIENT";
        public const string CONGIGURE_NAME = "IBankAPIConfig";
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
