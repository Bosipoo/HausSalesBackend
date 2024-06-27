namespace HausSalesBackend.Models
{
    public class ExternalLoginModel
    {
        public string Provider { get; set; } // e.g., "Google"
        public string IdToken { get; set; }  // The token received from the external provider
    }
}
