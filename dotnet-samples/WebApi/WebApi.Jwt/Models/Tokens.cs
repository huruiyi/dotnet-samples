using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace WebApiJwt.Models
{
    public class Tokens
    {
        public static readonly String SecurityKey ="354532gdf5gd1f5gdgf55kl3n54k3n5k32j5n32k354";

        public static readonly string SecurityIssuer = "Issuer";

        public static readonly string SecurityAudience = "Audience";
    }
}
