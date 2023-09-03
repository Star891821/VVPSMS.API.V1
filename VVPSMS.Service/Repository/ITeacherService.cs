using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Repository
{
    public interface ITeacherService
    {
        Task<CommonResponse> UpdateTeacherProfile(TeacherDto teacherDto);
    }
}
