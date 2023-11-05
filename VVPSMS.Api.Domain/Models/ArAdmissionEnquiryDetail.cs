using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class ArAdmissionEnquiryDetail
{
    public int AradmissionenquirydetailsId { get; set; }

    public int? ArformId { get; set; }

    public int? MstenquiryquestiondetailsId { get; set; }

    public string? EnquiryResponse { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ArAdmissionForm? Arform { get; set; }
}
