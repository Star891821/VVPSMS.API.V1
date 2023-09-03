using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstAdmissionStatus
{
    public int StatusId { get; set; }

    public int StatusCode { get; set; }

    public string StatusDescription { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
