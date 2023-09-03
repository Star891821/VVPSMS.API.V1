using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class AdmissionDocument
{
    public int DocumentId { get; set; }

    public int FormId { get; set; }

    public string DocumentName { get; set; } = null!;

    public string DocumentPath { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual AdmissionForm Form { get; set; } = null!;
}
