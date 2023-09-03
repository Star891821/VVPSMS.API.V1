using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers
{
    public class StudentService : IStudentService
    {
        readonly VvpsmsdbContext _vvpsmsdbContext;
        public StudentService()
        {
            _vvpsmsdbContext = new VvpsmsdbContext();
        }

        public async Task<CommonResponse> UpdateStudentProfile(StudentDto studentDto)
        {
            var response = new CommonResponse();
            try
            {
                var studentProfile = new Student()
                {
                    StudentUsername = studentDto.StudentUsername,
                    StudentPassword = studentDto.StudentPassword,
                    StudentGivenName = studentDto.StudentGivenName,
                    StudentSurname = studentDto.StudentSurname,
                    StudentPhone = studentDto.StudentPhone,
                    StudentRole =  studentDto.StudentRole,
                    StudentLoginType= studentDto.StudentLoginType,
                    Enforce2Fa = studentDto.Enforce2Fa,
                    CreatedAt = studentDto.CreatedAt,
                    CreatedBy = studentDto.CreatedBy,
                    ModifiedAt = studentDto.ModifiedAt,
                    ModifiedBy = studentDto.ModifiedBy,
                    LastloginAt= studentDto.LastloginAt
                };

                _vvpsmsdbContext.Students.Add(studentProfile);
                _vvpsmsdbContext.SaveChanges();

                if(studentDto.Documents != null)
                {
                    foreach (var item in studentDto.Documents)
                    {
                        var studentdocument = new Document()
                        {
                            StudentId = studentProfile.StudentId,                            
                            DocumentName= item.DocumentName,
                            DocumentPath= item.DocumentPath,
                            CreatedAt = studentDto.CreatedAt,
                            CreatedBy = studentDto.CreatedBy,
                            ModifiedAt = studentDto.ModifiedAt,
                            ModifiedBy = studentDto.ModifiedBy
                        };

                        _vvpsmsdbContext.Documents.Add(studentdocument);
                        _vvpsmsdbContext.SaveChanges();
                    }
                }

                response.Id = studentProfile.StudentId;
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
