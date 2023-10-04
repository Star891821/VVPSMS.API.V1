using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class MstEnquiryQuestionDetailDto
    {
        public int MstenquiryquestiondetailsId { get; set; }

        public string? EnquiryQuestion { get; set; }

        public int? MstenquiryquestiontypedetailsId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        //public virtual List<AdmissionEnquiryDetailDto> ListOfAdmissionEnquiryDetails { get; set; }
        public virtual List<MstEnquiryAnswerDetailDto> ListOfMstEnquiryAnswerDetails { get; set; }
        //public virtual MstEnquiryQuestionTypeDetailDto MstEnquiryQuestionTypeDetails { get; set; }
    }
}
