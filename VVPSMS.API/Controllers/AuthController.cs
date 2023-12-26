using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using Org.BouncyCastle.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Models;
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
            //  _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

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
            if (loginRequest != null)
            {
                if (loginRequest.UserType == "Applicant")
                {
                    var loginResponse = InsertOrUpdate(loginRequest).Result;
                    return Ok(Generatejwttokenwithnewresponse(loginResponse));
                }
                else
                {
                    var loginResponse = await _dataRepository.LoginDetails(loginRequest);
                    return Ok(Generatejwttoken(loginResponse));
                }
            }
            return response;
        }
        private LoginAuthResponse Generatejwttoken(LoginResponseDto loginResponse)
        {
            if (loginResponse != null && loginResponse.Status == true)
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
                        new Claim(JwtRegisteredClaimNames.Sub,loginResponse.email),
                        new Claim(JwtRegisteredClaimNames.Email,loginResponse.email),
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
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                var authResponse = new LoginAuthResponse()
                {
                    JwtToken = jwtToken,
                    ExpiryDateTime = expires.ToString(),
                    LoggedInUser = loginResponse.Role,
                    UserId = loginResponse.Id
                };
                return authResponse;
            }
            return null;
        }
        private ApplicantAuthResponse Generatejwttokenwithnewresponse(ApplicantResponseDto loginResponse)
        {
            if (loginResponse != null)
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
                        new Claim(JwtRegisteredClaimNames.Sub,loginResponse.Applicantemail),
                        new Claim(JwtRegisteredClaimNames.Email,loginResponse.Applicantemail),
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
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                var authResponse = new ApplicantAuthResponse()
                {
                    JwtToken = jwtToken,
                    ExpiryDateTime = expires.ToString(),
                    ApplicantId = loginResponse.ApplicantId,
                    ApplicantGivenName = loginResponse.ApplicantGivenName,
                    RoleId = loginResponse.RoleId,
                    Applicantemail = loginResponse.Applicantemail,
                    ApplicantLoginType = loginResponse.ApplicantLoginType,
                    Applicantname = loginResponse.Applicantname,
                    Applicantpassword = loginResponse.Applicantpassword,
                    ApplicantPhone = loginResponse.ApplicantPhone,
                    ApplicantSurname = loginResponse.ApplicantSurname,
                    Enforce2Fa = loginResponse.Enforce2Fa
                    
                };
                return authResponse;
            }
            return null;
        }
        [HttpPost]
        private async Task<ApplicantResponseDto> InsertOrUpdate(LoginRequestDto loginRequestDto)
        {
            var _oUser = new ApplicantResponseDto();
            using (var httpclient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(loginRequestDto), Encoding.UTF8, "application/json");

                using (var response = await httpclient.PostAsync("https://localhost:7210/api/Applicant/InsertOrUpdateWithResponse", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    _oUser = JsonConvert.DeserializeObject<ApplicantResponseDto>(apiResponse);
                }
            }
            return _oUser;
        }
    }

}
