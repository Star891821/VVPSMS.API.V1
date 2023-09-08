using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Students;

namespace VVPSMS.Service.DataManagers.StudentDataManagers
{
    public class StudentDocumentService : GenericService<StudentDocument>, IStudentDocumentService
    {
        public StudentDocumentService(VvpsmsdbContext context) : base(context)
        {
        }


    }
}
