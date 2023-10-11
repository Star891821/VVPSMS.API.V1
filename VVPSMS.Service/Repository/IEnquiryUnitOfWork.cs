using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Service.Repository
{
    public interface IEnquiryUnitOfWork : IDisposable
    {
        IMstEnquiryQuestionDetails mstEnquiryQuestionDetails { get; }
        IMstEnquiryAnswerDetails mstEnquiryAnswerDetails { get; }
        void RemoveNullableEntitiesFromDb();
        void RemoveEntitiesById(int id);
        bool Complete();
        Task CompleteAsync();
    }
}
