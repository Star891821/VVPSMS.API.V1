using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class SiblingInfo
{
    public int SiblingId { get; set; }

    public int FormId { get; set; }

    public string? SiblingName { get; set; }

    public DateTime? SiblingDob { get; set; }

    public string? SiblingGender { get; set; }

    public string? SiblingSchool { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual AdmissionForm Form { get; set; } = null!;
}
