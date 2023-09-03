using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using VVPSMS.Service.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers
{
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly JwtConfig Config;
        public JwtAuthManager(IOptions<JwtConfig> config)
        {
            Config = config.Value;
        }

        public Tuple<string, DateTime> GenerateToken(string value, DateTime now, Guid id)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, value),
                new Claim(JwtRegisteredClaimNames.Jti, id.ToString())
            };
            var sCreds = new SigningCredentials(new SymmetricSecurityKey(Config.GetSecretKey()), SecurityAlgorithms.HmacSha256Signature);

            var exp = now.Add(Config.AccessTokenExpiry);

            var jToken = new JwtSecurityToken(Config.Issuer, Config.Audience, claims, now, exp, sCreds);
            var token = new JwtSecurityTokenHandler().WriteToken(jToken);

            var item1 = token;
            var item2 = exp;

            return (item1, item2).ToTuple();
        }

        public Tuple<string, DateTime> GenerateRefreshToken(DateTime now)
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            var exp = now.Add(TimeSpan.FromDays(2));

            return (Convert.ToBase64String(randomNumber), exp).ToTuple();
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidIssuer = Config.Issuer,
                    ValidAudience = Config.Audience,
                    ClockSkew = TimeSpan.FromMinutes(1),
                    IssuerSigningKey = new SymmetricSecurityKey(Config.GetSecretKey())
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}
