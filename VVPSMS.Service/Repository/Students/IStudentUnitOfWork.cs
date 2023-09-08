using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Service.Repository.Students;

namespace VVPSMS.Service.Repository.Students
{
    public interface IStudentUnitOfWork : IDisposable
    {
        IStudentDocumentService DocumentService { get; }
        IStudentService StudentService { get; }
        Task CompleteAsync();

    }
}
