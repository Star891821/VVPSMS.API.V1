using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstEnquiryQuestionTypeDetail
{
    public int MstenquiryquestiontypedetailsId { get; set; }

    public string? EnquiryQuestionType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<MstEnquiryQuestionDetail> MstEnquiryQuestionDetails { get; set; } = new List<MstEnquiryQuestionDetail>();
}
