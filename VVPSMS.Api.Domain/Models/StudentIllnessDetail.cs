using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class StudentIllnessDetail
{
    public int StudentillnessdetailsId { get; set; }

    public int? FormId { get; set; }

    public string? IllnessType { get; set; }

    public string? IllnessName { get; set; }

    public string? IllnessDate { get; set; }

    public string? IllnessDetails { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual AdmissionForm? Form { get; set; }
}
