using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Repository
{
    public interface ILoginService
    {
        Task<LoginResponseDto> LoginDetails(LoginRequestDto loginRequest);
        Task<NewLoginResponseDto> LoginDetails1(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);
        Task<LoginResponseDto> GetEmployeeExternalvalidationAsync(string userId);
    }
}
