using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class MstEnquiryAnswerDetailDto
    {

        public int MstenquiryanswerdetailsId { get; set; }

        public int MstenquiryquestiondetailsId { get; set; }

        public string? EnquiryAnswerDetails { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
