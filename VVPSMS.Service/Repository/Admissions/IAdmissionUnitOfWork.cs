using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IAdmissionUnitOfWork : IDisposable
    {
        IAdmissionDocumentService AdmissionDocumentService { get; }
        IAdmissionService AdmissionService { get; }
        Task CompleteAsync();

    }
}
