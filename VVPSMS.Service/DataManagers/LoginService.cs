using Microsoft.EntityFrameworkCore;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers
{
    public class LoginService: ILoginService
    {
        readonly VvpsmsdbContext _vvpsmsdbContext;
        public LoginService()
        {
            _vvpsmsdbContext = new VvpsmsdbContext();
        }

        public async Task<LoginResponseDto> LoginDetails(LoginRequestDto loginRequest)
        {
            LoginResponseDto loginResponseDto = null;
            try
            {
                switch (loginRequest.LoginUser.ToUpper())
                {
                    case "STUDENT":
                        var student = await _vvpsmsdbContext.Students.FirstOrDefaultAsync(x => x.StudentUsername == loginRequest.UserId && x.StudentPassword == loginRequest.Password);
                        if (student != null)
                        {
                            loginResponseDto = new LoginResponseDto()
                            {
                                UserName = student.StudentUsername,
                                GivenName = student.StudentGivenName,
                                Phone = student.StudentPhone ?? string.Empty,
                                Status=true,
                                Message="Valid User"
                            };
                        }
                        break;
                    case "TEACHER":
                        var teacher = await _vvpsmsdbContext.Teachers.FirstOrDefaultAsync(x => x.TeacherUsername == loginRequest.UserId && x.TeacherPassword == loginRequest.Password);
                        if (teacher != null)
                        {
                            loginResponseDto = new LoginResponseDto()
                            {
                                UserName = teacher.TeacherUsername,
                                GivenName = teacher.TeacherGivenName,
                                Phone = teacher.TeacherPhone ?? string.Empty,
                                Status = true,
                                Message = "Valid User"
                            };
                        }
                        break;
                    default:                        
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            return loginResponseDto;
        }

        public async Task<LoginResponseDto> GetEmployeeExternalvalidationAsync(string userId)
        {
            LoginResponseDto loginResponseDto = null;
            try
            {
                                   }
            catch (Exception ex)
            {

            }
            return loginResponseDto;
        }
    }
}
