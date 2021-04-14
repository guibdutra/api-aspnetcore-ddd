using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreDDD.Infrastructure.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredencials { get; set; }

        public SigningConfigurations()
        {
            using(var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredencials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}