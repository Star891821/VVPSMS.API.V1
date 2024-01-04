using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class AdmissionPayment
{
    public int AdmissionpaymentId { get; set; }

    public int UserId { get; set; }

    public int Status { get; set; }

    public string ImageName { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public string Useremail { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual MstUser User { get; set; } = null!;
}
