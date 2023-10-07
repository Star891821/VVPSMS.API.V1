using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class AdmissionEnquiryDetail
{
    public int AdmissionenquirydetailsId { get; set; }

    public int? FormId { get; set; }

    public int? MstenquiryquestiondetailsId { get; set; }

    public string? EnquiryResponse { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual AdmissionForm? Form { get; set; }

    public virtual MstEnquiryQuestionDetail? Mstenquiryquestiondetails { get; set; }
}
