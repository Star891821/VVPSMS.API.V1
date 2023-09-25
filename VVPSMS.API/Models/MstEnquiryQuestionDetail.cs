using System;
using System.Collections.Generic;

namespace VVPSMS.API.Models;

public partial class MstEnquiryQuestionDetail
{
    public int MstenquiryquestiondetailsId { get; set; }

    public string? EnquiryQuestion { get; set; }

    public int? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<AdmissionEnquiryDetail> AdmissionEnquiryDetails { get; set; } = new List<AdmissionEnquiryDetail>();
}
