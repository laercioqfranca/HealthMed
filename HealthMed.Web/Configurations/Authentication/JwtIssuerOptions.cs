using Microsoft.IdentityModel.Tokens;

namespace HealthMed.Web.Configurations.Authentication
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
