using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository
{
    public interface IMstEnquiryAnswerDetails :ICommonService<MstEnquiryAnswerDetail>
    {
        void RemoveRangeofDetails();
        void RemoveRangeofEnquiryAnswers(int id);
    }
}
