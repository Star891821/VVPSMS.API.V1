using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers
{
    public class TeacherService : ITeacherService
    {
        readonly VvpsmsdbContext _vvpsmsdbContext;
        public TeacherService()
        {
            _vvpsmsdbContext = new VvpsmsdbContext();
        }

        public async Task<CommonResponse> UpdateTeacherProfile(TeacherDto teacherDto)
        {
            var response = new CommonResponse();
            try
            {
                var teacherProfile = new Teacher()
                {
                    TeacherUsername = teacherDto.TeacherUsername,
                    TeacherPassword = teacherDto.TeacherPassword,
                    TeacherGivenName = teacherDto.TeacherGivenName,
                    TeacherSurname = teacherDto.TeacherSurname,
                    TeacherPhone = teacherDto.TeacherPhone,
                    TeacherRole = teacherDto.TeacherRole,
                    TeacherLoginType = teacherDto.TeacherLoginType,
                    Enforce2Fa = teacherDto.Enforce2Fa,
                    CreatedAt = teacherDto.CreatedAt,
                    CreatedBy = teacherDto.CreatedBy,
                    ModifiedAt = teacherDto.ModifiedAt,
                    ModifiedBy = teacherDto.ModifiedBy,
                    LastloginAt = teacherDto.LastloginAt
                };

                _vvpsmsdbContext.Teachers.Add(teacherProfile);
                _vvpsmsdbContext.SaveChanges();

                if (teacherDto.Documents != null)
                {
                    foreach (var item in teacherDto.Documents)
                    {
                        var teacherdocument = new Document()
                        {                            
                            TeacherId = teacherProfile.TeacherId,
                            DocumentName = item.DocumentName,
                            DocumentPath = item.DocumentPath,
                            CreatedAt = teacherDto.CreatedAt,
                            CreatedBy = teacherDto.CreatedBy,
                            ModifiedAt = teacherDto.ModifiedAt,
                            ModifiedBy = teacherDto.ModifiedBy
                        };

                        _vvpsmsdbContext.Documents.Add(teacherdocument);
                        _vvpsmsdbContext.SaveChanges();
                    }
                }

                response.Id = teacherProfile.TeacherId;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
