using Microsoft.EntityFrameworkCore;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Models;
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
                                Message="Valid User",
                                Role="STUDENT"
                            };
                        }
                        break;
                    case "TEACHER":
                        var teacher = await _vvpsmsdbContext.Teachers.FirstOrDefaultAsync(x => x.TeacherUsername == loginRequest.UserId 
                        && x.TeacherPassword == loginRequest.Password);
                        if (teacher != null)
                        {
                            loginResponseDto = new LoginResponseDto()
                            {
                                UserName = teacher.TeacherUsername,
                                GivenName = teacher.TeacherGivenName,
                                Phone = teacher.TeacherPhone ?? string.Empty,
                                Status = true,
                                Message = "Valid User",
                                Role = "TEACHER"
                            };
                        }
                        break;
                    default:
                        var user = await _vvpsmsdbContext.MstUsers.FirstOrDefaultAsync(x => x.Username == loginRequest.UserId
                        && x.Userpassword == loginRequest.Password && x.RoleId==loginRequest.RoleId);
                        if (user != null)
                        {
                            var loggedInRole= await _vvpsmsdbContext.MstUserRoles.FirstOrDefaultAsync(x=>x.RoleId==user.RoleId);
                            loginResponseDto = new LoginResponseDto()
                            {
                                UserName = user.Username,
                                GivenName = user.UserGivenName,
                                Phone = user.UserPhone ?? string.Empty,
                                Status = true,
                                Message = "Valid User",
                                Role = loggedInRole!=null? loggedInRole.RoleName:"Unknown"
                            };
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            return loginResponseDto;
        }

        public async Task<NewLoginResponseDto> FetchOrInsertLoginDetails(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        {
            NewLoginResponseDto? loginResponseDto = null;
            try
            {
                var user = await _vvpsmsdbContext.MstUsers.FirstOrDefaultAsync(x => x.Useremail == payload.Email);
                MstUserRole? loggedInRole = null;
                if (user != null)
                {
                   loggedInRole = await _vvpsmsdbContext.MstUserRoles.FirstOrDefaultAsync(x => x.RoleId == user.RoleId);                  
                }
                else
                {
                    user = new MstUser()
                    {
                        Username = payload.Email,
                        Userpassword = "123",
                        UserGivenName = payload.Email,
                        UserSurname = payload.Email,
                        Useremail = payload.Email,
                        UserLoginType = "User",
                        Enforce2Fa = 0,
                        RoleId = 1,
                        CreatedAt = DateTime.Now
                    };
                    _vvpsmsdbContext.MstUsers.Add(user);
                    _vvpsmsdbContext.SaveChanges();
                }
                loginResponseDto = new NewLoginResponseDto()
                {
                    UserId = user.UserId,
                    UserName = user.Username,
                    GivenName = user.UserGivenName,
                    Phone = user.UserPhone ?? string.Empty,
                    Status = true,
                    Message = "Valid User",
                    Role = loggedInRole != null ? loggedInRole.RoleName : "Unknown"
                };

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
