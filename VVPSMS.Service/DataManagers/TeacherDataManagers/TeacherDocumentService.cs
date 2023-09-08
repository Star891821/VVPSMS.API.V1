using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Teachers;

namespace VVPSMS.Service.DataManagers.TeacherDataManagers
{
    public class TeacherDocumentService : GenericService<TeacherDocument>, ITeacherDocumentService
    {
        public TeacherDocumentService(VvpsmsdbContext context) : base(context)
        {
        }


    }
}
