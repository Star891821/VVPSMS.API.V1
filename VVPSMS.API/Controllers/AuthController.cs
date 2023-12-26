using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ILoginService _dataRepository;
        private static Logger logger = LogManager.GetLogger("AuthController");
        public AuthController(IConfiguration configuration, ILoginService dataRepository)
        {
            _dataRepository = dataRepository;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpPost("AuthTest")]
        public async Task<IActionResult> AuthTest()
        {
            
            return Ok("Hello");
        }
        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpPost("Auth")]
        public async Task<IActionResult> Auth(LoginRequestDto loginRequest)
        {
            IActionResult response = Unauthorized();
            if(loginRequest != null)
            {
                var loginResponse = await _dataRepository.LoginDetails(loginRequest);
                if(loginResponse!=null && loginResponse.Status ==true)
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                    var signingCredentails = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha384Signature
                        );
                    var subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,loginRequest.UserId),
                        new Claim(JwtRegisteredClaimNames.Email,loginRequest.UserId),
                    });
                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentails
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token=tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken=tokenHandler.WriteToken(token);

                    var authResponse = new LoginAuthResponse()
                    {
                        JwtToken = jwtToken,
                        ExpiryDateTime= expires.ToString(),
                        LoggedInUser= loginResponse.Role
                    };
                    return Ok(authResponse);
                }                
            }
            return response;
        }
    }
}
