using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class ArSiblingInfo
{
    public int ArsiblingId { get; set; }

    public int? ArformId { get; set; }

    public string? SiblingName { get; set; }

    public DateTime? SiblingDob { get; set; }

    public string? SiblingGender { get; set; }

    public string? SiblingSchool { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ArAdmissionForm? Arform { get; set; }
}
