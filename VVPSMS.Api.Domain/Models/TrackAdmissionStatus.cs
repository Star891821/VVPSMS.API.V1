using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class TrackAdmissionStatus
{
    public int TrackId { get; set; }

    public int? FormId { get; set; }

    public int? AdmissionStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }
}
