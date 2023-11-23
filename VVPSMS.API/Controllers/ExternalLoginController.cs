using Azure.Storage.Blobs.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared.Interfaces;
using AppleAuth;
using AppleAuth.TokenObjects;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using System.Globalization;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExternalLoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IExternalLoginAppService _appSvc;
        private readonly ILoginService _dataRepository;
        private ILog _logger;
        private readonly ILoggerService _loggerService;
        public ExternalLoginController(IExternalLoginAppService appSvc, ILoginService dataRepository, ILog logger, ILoggerService loggerService, IConfiguration configuration)
        {
            _dataRepository = dataRepository;
            _configuration = configuration;
            _appSvc = appSvc;
            _logger = logger;
            _loggerService = loggerService;
        }
  //      /// <summary>
  //      /// 
  //      /// </summary>
  //      /// <param name="request"></param>
  //      /// <returns></returns>
  //      [ProducesResponseType(typeof(LoginResponseDto), 200)]
  //      [ProducesResponseType(typeof(bool?), 400)]
  //      [ProducesResponseType(typeof(bool?), 500)]
  //      [HttpPost("google")]
  //      public async Task<LoginResponseDto> GoogleAuthenticationAsync([FromBody] GoogleRQ request)
  //      {
  //          try
  //          {
  //              _logger.Information($"GoogleAuthenticationAsync API Started");
  //              //  _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GoogleAuthenticationAsync API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              var ret = await _appSvc.GoogleAuthenticationAsync(request.userId);
  //              return ret;
  //          }
  //          catch (Exception ex)
  //          {
  //              _logger.Error($"Something went wrong inside GoogleAuthenticationAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
  //              _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GoogleAuthenticationAsync for" + typeof(ExternalLoginController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              return null;
  //          }
  //          finally
  //          {
  //              _logger.Information($"GoogleAuthenticationAsync API completed Successfully");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GoogleAuthenticationAsync API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //          }
  //      }
  //      [ApiExplorerSettings(IgnoreApi = true)]
  //      [HttpGet("google/callback")]
  //      public async Task<bool> GoogleCallbackAsync()
  //      {
  //          try
  //          {
  //              _logger.Information($"GoogleCallbackAsync API Started");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GoogleCallbackAsync API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              return await Task.FromResult(true);
  //          }
  //          catch (Exception ex)
  //          {
  //              _logger.Error($"Something went wrong inside GoogleCallbackAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
  //              _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GoogleCallbackAsync for" + typeof(ExternalLoginController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              return false;
  //          }
  //          finally
  //          {
  //              _logger.Information($"GoogleCallbackAsync API completed Successfully");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GoogleCallbackAsync API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //          }
  //      }


  //      /// <summary>
  //      /// Login by Microsoft credentials 
  //      /// </summary>
  //      /// <param name="request">request</param>
  //      ///	<returns>
  //      /// <response code="200">Operation success</response>
  //      /// <response code="400">Invalid request.</response>
  //      /// <response code="500">Server Error. Something went wrong</response>
  //      /// </returns>
  //      [ProducesResponseType(typeof(LoginResponseDto), 200)]
  //      [ProducesResponseType(typeof(bool?), 400)]
  //      [ProducesResponseType(typeof(bool?), 500)]
  //      [HttpPost("microsoft")]
  //      public async Task<LoginResponseDto> MicrosoftAuthenticationAsync([FromBody] MicrosoftRQ request)
  //      {
  //          try
  //          {
  //              await _appSvc.LogErrorAsync("MicrosoftAuthenticationAsync-Start", request.userId, "request.userId");
  //              var LoginRS = await _appSvc.MicrosoftAuthenticationAsync(request);
  //              return LoginRS;
  //          }
  //          catch (Exception ex)
  //          {
  //              await _appSvc.LogErrorAsync("MicrosoftAuthenticationAsync-Exception", ex.Message, ex.StackTrace);
  //              return null;
  //          }
  //          finally
  //          {
  //              _logger.Information($"MicrosoftAuthenticationAsync API completed Successfully");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "MicrosoftAuthenticationAsync API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //          }

  //      }
  //      /// <summary>
  //      /// MicrosoftCallbackAsync
  //      /// </summary>
  //      /// <returns></returns>
  //    //  [ApiExplorerSettings(IgnoreApi = true)]
  //      [HttpGet("microsoft/callback")]
  //      public async Task<bool> MicrosoftCallbackAsync()
  //      {
  //          try
  //          {
  //              _logger.Information($"MicrosoftCallbackAsync API Started");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "MicrosoftCallbackAsync API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              return await Task.FromResult(true);
  //          }
  //          catch (Exception ex)
  //          {
  //              _logger.Error($"Something went wrong inside MicrosoftCallbackAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
  //              _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at MicrosoftCallbackAsync for" + typeof(ExternalLoginController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              return false;
  //          }
  //          finally
  //          {
  //              _logger.Information($"MicrosoftCallbackAsync API completed Successfully");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "MicrosoftCallbackAsync API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //          }
  //      }
  //      /// <summary>
		///// Login by Apple credentials 
		///// </summary>
		///// <param name="request">Auth token</param>
		/////	<returns>
		///// <response code="200">Operation success</response>
		///// <response code="400">Invalid request.</response>
		///// <response code="500">Server Error. Something went wrong</response>
		///// </returns>
		//[ProducesResponseType(typeof(LoginResponseDto), 200)]
  //      [ProducesResponseType(typeof(bool?), 400)]
  //      [ProducesResponseType(typeof(bool?), 500)]
  //      [HttpPost("apple")]
  //      public async Task<LoginResponseDto> AppleAuthenticationAsync([FromBody] AppleRQ request)
  //      {
  //          try
  //          {
  //              _logger.Information($"AppleAuthenticationAsync API Started");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "AppleAuthenticationAsync API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              var ret = await _appSvc.AppleAuthenticationAsync(request.IdToken);
  //              return ret;
  //          }
  //          catch (Exception ex)
  //          {
  //              _logger.Error($"Something went wrong inside AppleAuthenticationAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
  //              _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at AppleAuthenticationAsync for" + typeof(ExternalLoginController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //              return null;
  //          }
  //          finally
  //          {
  //              _logger.Information($"AppleAuthenticationAsync API completed Successfully");
  //              _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "AppleAuthenticationAsync API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
  //          }
  //      }

        public class UserView
        {
            public string tokenId { get; set; }
        }
        [AllowAnonymous]
        [HttpPost("GetoAuthAppleToken")]
        public async Task<IActionResult> AppleGetToken(InitialTokenResponse response)
        {
            try
            {
                //Read the content of they key file.
                string privateKey = System.IO.File.ReadAllText("path/to/file.p8");

                //Create a new instance of AppleAuthProvider
                AppleAuth.AppleAuthProvider provider = new AppleAuthProvider("MyClientID", "MyTeamID", "MyKeyID", "https://myredirecturl.com/HandleResponseFromApple", "State1");

                //Retrieve an authorization token
                AuthorizationToken authorizationToken = await provider.GetAuthorizationToken(response.code, privateKey);

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("VerifyoAuthAppleToken")]
        public void VerifyAppleIDToken(string token, string clientId)
        {
            //Read the token and get it's claims using System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims;
            SecurityKey publicKey; SecurityToken validatedToken;

            //Get the expiration of the token and convert its value from unix time seconds to DateTime object
            var expirationClaim = claims.FirstOrDefault(x => x.Type == "exp").Value;
            var expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationClaim)).DateTime;

            if (expirationTime < DateTime.UtcNow)
            {
                throw new SecurityTokenExpiredException("Expired token");
            }

            using (var httpClient = new HttpClient())
            {
                //Request Apple's JWKS used for verifying the tokens.
                var applePublicKeys = httpClient.GetAsync("https://appleid.apple.com/auth/keys");
                var keyset = new JsonWebKeySet(applePublicKeys.Result.Content.ReadAsStringAsync().Result);

                //Since there is more than one JSON Web Key we select the one that has been used for our token.
                //This is achieved by filtering on the "Kid" value from the header of the token
                publicKey = keyset.Keys.FirstOrDefault(x => x.Kid == jwtSecurityToken.Header.Kid);
            }

            //Create new TokenValidationParameters object which we pass to ValidateToken method of JwtSecurityTokenHandler.
            //The handler uses this object to validate the token and will throw an exception if any of the specified parameters is invalid.
            var validationParameters = new TokenValidationParameters
            {
                ValidIssuer = "https://appleid.apple.com",
                IssuerSigningKey = publicKey,
                ValidAudience = clientId
            };

            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        }

        [AllowAnonymous]
        [HttpPost("VerifyoAuthMicrosoftToken")]
        public void MicroSoftAzureTokenValidation()
        {
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IkN0VHVoTUptRDVNN0RMZHpEMnYyeDNRS1NSWSJ9.eyJhdWQiOiI3YjFjZTFhZC1hZjE1LTRlNWYtOWFlNC1hYWYwYTY4YTdhYjQiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vZThlNmQwMTgtYTgzNC00MDZiLTlmNDMtMmU5NGFlNDI1ODc2L3YyLjAiLCJpYXQiOjE1ODkyODQ2OTEsIm5iZiI6MTU4OTI4NDY5MSwiZXhwIjoxNTg5Mjg4NTkxLCJhaW8iOiJBVVFBdS84UEFBQUEyNWpRNzJBc3IyWHBYMEJlUkZRNU1lTTdSLy8zbnpIbUxDUHNYekJYRWZpSGlkQWM4Y0RPNHJoUUVEdk56OWtnRTdPK1pYbmxNTTVRNmk4RjZYY0hLZz09IiwibmFtZSI6IlZpamFpIEFuYW5kIFJhbWFsaW5nYW0iLCJub25jZSI6IjY1OWM5MjU0LTQyN2YtNDg5MC05ODQ5LTU0ZTk1Yjc0NDYyNCIsIm9pZCI6ImU2YmFkYTg2LTk4NDktNGFhNC1hZWQ0LTg5YzZlZmE5YTc0MSIsInByZWZlcnJlZF91c2VybmFtZSI6InZpamFpYW5hbmRAQzk4Ni5vbm1pY3Jvc29mdC5jb20iLCJzdWIiOiJIdjhtQ3RDVkx1NW8wYklrSDJVd2RCTnVUWTlqeC1RNUU4LTVuYU5pdkFJIiwidGlkIjoiZThlNmQwMTgtYTgzNC00MDZiLTlmNDMtMmU5NGFlNDI1ODc2IiwidXRpIjoiVml0alZEcVh5RS0yaWNLQUlRT19BQSIsInZlciI6IjIuMCJ9.UAT3FkgCBYqM7Mfux1V-yF1QTqg0Dlz4Y2G8VQqNqg3WXWdQWf8v4MHcrZVzycV6FSA0-C4ANRpkBxeX1mdmtic4l6e5onOsRS3r_PsWpp7mew_XlTt9TQ1W1pO5dn6lw6J4U3k41kmXVAPwH9hbZNEmVVM6KjNQLW-SdCfaJJIB0XVIqEK2HOlBPxSI8hugh9S5yRMYz6-xi7SrG-wQJtsa9s7Wz5O4FYW2YmjHdUIdj_xwJbfS6_rknJetO756okz4tHY70N3GAKlr_zvfXvuAMjXfsXQNQN5-TQnDcWVkvK6SrhCGQunlPmjvvTvJyp7KLZVrRhxnz8w98yaEfA";
            string myTenant = "e8e6d018-a834-406b-9f43-2e94ae425876";
            var myAudience = "7b1ce1ad-af15-4e5f-9ae4-aaf0a68a7ab4";
            var myIssuer = String.Format(CultureInfo.InvariantCulture, "https://login.microsoftonline.com/{0}/v2.0", myTenant);
            var mySecret = "t.GDqjoBYBhB.tRC@lbq1GdslFjk8=57";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
            var stsDiscoveryEndpoint = String.Format(CultureInfo.InvariantCulture, "https://login.microsoftonline.com/{0}/.well-known/openid-configuration", myTenant);
            var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint, new OpenIdConnectConfigurationRetriever());
            var config =  configManager.GetConfigurationAsync();

            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidAudience = myAudience,
                ValidIssuer = myIssuer,
             //   IssuerSigningKeys = config.SigningKeys, //UnComment While Validating this code base
                ValidateLifetime = false,
                IssuerSigningKey = mySecurityKey
            };

            var validatedToken = (SecurityToken)new JwtSecurityToken();

            // Throws an Exception as the token is invalid (expired, invalid-formatted, etc.)  
            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);


        }


        [AllowAnonymous]
        [HttpPost("oAuthGoogleToken")]
        public async Task<IActionResult> Google([FromBody] UserView userView)
        {
            try
            {
                var payload = GoogleJsonWebSignature.ValidateAsync(userView.tokenId, new GoogleJsonWebSignature.ValidationSettings()).Result;
                if (payload != null)
                {
                    var user = await _dataRepository.FetchOrInsertLoginDetails(payload);
                    if (user != null)
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
                        new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email,user.UserId.ToString()),
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
                            //LoggedInUser = user.Role,
                            UserId = user.Id,
                            UserName = user.UserName,
                            GivenName = user.GivenName,
                            SurName = user.SurName,
                            Phone = user.Phone,
                            Role = user.Role
                        };
                        return Ok(authResponse);
                    }
                    else
                    {
                        return BadRequest("Fetching Or Insert Of User Failed");
                    }
                }
                else
                {
                    return BadRequest("Google Validation Failed");
                }
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest();
        }

    }
}
