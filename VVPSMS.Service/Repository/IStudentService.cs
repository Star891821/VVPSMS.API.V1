using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Repository
{
    public interface IStudentService
    {
        Task<CommonResponse> UpdateStudentProfile(StudentDto studentDto);
    }
}
