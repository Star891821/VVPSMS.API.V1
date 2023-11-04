using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstEnquiryQuestionDetail
{
    public int MstenquiryquestiondetailsId { get; set; }

    public string? EnquiryQuestion { get; set; }

    public int? MstenquiryquestiontypedetailsId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<AdmissionEnquiryDetail> AdmissionEnquiryDetails { get; set; } = new List<AdmissionEnquiryDetail>();

    public virtual ICollection<MstEnquiryAnswerDetail> MstEnquiryAnswerDetails { get; set; } = new List<MstEnquiryAnswerDetail>();

    public virtual MstEnquiryQuestionTypeDetail? Mstenquiryquestiontypedetails { get; set; }
}
