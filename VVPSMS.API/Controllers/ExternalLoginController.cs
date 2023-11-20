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
