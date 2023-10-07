using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstEnquiryAnswerDetail
{
    public int MstenquiryanswerdetailsId { get; set; }

    public int? MstenquiryquestiondetailsId { get; set; }

    public string? EnquiryAnswerDetails { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual MstEnquiryQuestionDetail? Mstenquiryquestiondetails { get; set; }
}
