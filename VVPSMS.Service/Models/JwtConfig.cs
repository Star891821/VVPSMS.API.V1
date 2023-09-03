using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Service.Models
{
    public class JwtConfig
    {
        public const string Claim_Name = "Name";

        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan AccessTokenExpiry { get; set; }
        public TimeSpan RefreshTokenExpiry { get; set; }

        public byte[] GetSecretKey()
        {
            return Convert.FromBase64String(SigningKey);
        }
    }
}
