using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class ArEmergencyContactDetail
{
    public int AremergencycontactdetailsId { get; set; }

    public int? ArformId { get; set; }

    public string? Name { get; set; }

    public string? ContactNumber { get; set; }

    public string? Relationship { get; set; }

    public string? NameofparentIncaseofstaffWard { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ArAdmissionForm? Arform { get; set; }
}
