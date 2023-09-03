using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Repository
{
    public interface ILoginService
    {
        Task<LoginResponseDto> LoginDetails(LoginRequestDto loginRequest);

        Task<LoginResponseDto> GetEmployeeExternalvalidationAsync(string userId);
    }
}
