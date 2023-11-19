using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Repository
{
    public interface ILoginService
    {
        Task<LoginResponseDto> LoginDetails(LoginRequestDto loginRequest);
        Task<NewLoginResponseDto> FetchOrInsertLoginDetails(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);
        Task<LoginResponseDto> GetEmployeeExternalvalidationAsync(string userId);
    }
}
