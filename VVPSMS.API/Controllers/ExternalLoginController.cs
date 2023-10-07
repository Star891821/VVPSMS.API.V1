using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExternalLoginController : ControllerBase
    {
        private readonly IExternalLoginAppService _appSvc;
        private ILog _logger;
        public ExternalLoginController(IExternalLoginAppService appSvc, ILog logger)
        {
            _appSvc = appSvc;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        [ProducesResponseType(typeof(bool?), 400)]
        [ProducesResponseType(typeof(bool?), 500)]
        [HttpPost("google")]
        public async Task<LoginResponseDto> GoogleAuthenticationAsync([FromBody] GoogleRQ request)
        {
            try
            {
                _logger.Information($"GoogleAuthenticationAsync API Started");
                var ret = await _appSvc.GoogleAuthenticationAsync(request.userId);
                return ret;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GoogleAuthenticationAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
                return null;
            }
            finally
            {
                _logger.Information($"GoogleAuthenticationAsync API completed Successfully");
            }
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("google/callback")]
        public async Task<bool> GoogleCallbackAsync()
        {
            try
            {
                _logger.Information($"GoogleCallbackAsync API Started");
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GoogleCallbackAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
                return false;
            }
            finally
            {
                _logger.Information($"GoogleCallbackAsync API completed Successfully");
            }
        }
        /// <summary>
        /// Login by Microsoft credentials 
        /// </summary>
        /// <param name="request">request</param>
        ///	<returns>
        /// <response code="200">Operation success</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">Server Error. Something went wrong</response>
        /// </returns>
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        [ProducesResponseType(typeof(bool?), 400)]
        [ProducesResponseType(typeof(bool?), 500)]
        [HttpPost("microsoft")]
        public async Task<LoginResponseDto> MicrosoftAuthenticationAsync([FromBody] MicrosoftRQ request)
        {
            try
            {
                await _appSvc.LogErrorAsync("MicrosoftAuthenticationAsync-Start", request.userId, "request.userId");
               var LoginRS = await _appSvc.MicrosoftAuthenticationAsync(request);
                return LoginRS;
            }
            catch (Exception ex)
            {
                await _appSvc.LogErrorAsync("MicrosoftAuthenticationAsync-Exception", ex.Message, ex.StackTrace);
                return null;
            }
            finally
            {
                _logger.Information($"MicrosoftAuthenticationAsync API completed Successfully");
            }
            
        }
        /// <summary>
        /// MicrosoftCallbackAsync
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("microsoft/callback")]
        public async Task<bool> MicrosoftCallbackAsync()
        {
            try
            {
                _logger.Information($"MicrosoftCallbackAsync API Started");
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside MicrosoftCallbackAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
                return false;
            }
            finally
            {
                _logger.Information($"MicrosoftCallbackAsync API completed Successfully");
            }
        }
        /// <summary>
		/// Login by Apple credentials 
		/// </summary>
		/// <param name="request">Auth token</param>
		///	<returns>
		/// <response code="200">Operation success</response>
		/// <response code="400">Invalid request.</response>
		/// <response code="500">Server Error. Something went wrong</response>
		/// </returns>
		[ProducesResponseType(typeof(LoginResponseDto), 200)]
        [ProducesResponseType(typeof(bool?), 400)]
        [ProducesResponseType(typeof(bool?), 500)]
        [HttpPost("apple")]
        public async Task<LoginResponseDto> AppleAuthenticationAsync([FromBody] AppleRQ request)
        {
            try
            {
                _logger.Information($"AppleAuthenticationAsync API Started");
                var ret = await _appSvc.AppleAuthenticationAsync(request.IdToken);
                return ret;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside AppleAuthenticationAsync for" + typeof(ExternalLoginController).FullName + "entity with exception" + ex.Message);
                return null;
            }
            finally
            {
                _logger.Information($"AppleAuthenticationAsync API completed Successfully");
            }
        }
    }
}
