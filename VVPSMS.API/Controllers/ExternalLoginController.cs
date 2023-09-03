using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Business;
using VVPSMS.Service.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalLoginController : ControllerBase
    {
        private readonly IExternalLoginAppService _appSvc;
        public ExternalLoginController(IExternalLoginAppService appSvc)
        {
            _appSvc = appSvc;
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
            var ret = await _appSvc.GoogleAuthenticationAsync(request.userId);
            return ret;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("google/callback")]
        public async Task<bool> GoogleCallbackAsync()
        {
            return await Task.FromResult(true);
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
            LoginResponseDto LoginRS = null;

            try
            {
                await _appSvc.LogErrorAsync("MicrosoftAuthenticationAsync-Start", request.userId, "request.userId");
                LoginRS = await _appSvc.MicrosoftAuthenticationAsync(request);
            }
            catch (Exception ex)
            {
                await _appSvc.LogErrorAsync("MicrosoftAuthenticationAsync-Exception", ex.Message, ex.StackTrace);
            }
            return LoginRS;
        }
        /// <summary>
        /// MicrosoftCallbackAsync
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("microsoft/callback")]
        public async Task<bool> MicrosoftCallbackAsync()
        {
            return await Task.FromResult(true);
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
            var ret = await _appSvc.AppleAuthenticationAsync(request.IdToken);
            return ret;
        }
    }
}
