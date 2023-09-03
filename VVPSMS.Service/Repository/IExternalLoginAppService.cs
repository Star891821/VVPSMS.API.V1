using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Models;

namespace VVPSMS.Service.Repository
{
    public interface IExternalLoginAppService
    {
        Task<LoginResponseDto> GoogleAuthenticationAsync(string authCode);
        Task<LoginResponseDto> MicrosoftAuthenticationAsync(MicrosoftRQ request);
        Task<LoginResponseDto> AppleAuthenticationAsync(string idToken);
        Task<bool> LogErrorAsync(string notificationId, string requests, string remarks);
    }
}
