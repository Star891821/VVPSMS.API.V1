using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstSchoolGrade
{
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<AdmissionForm> AdmissionForms { get; set; } = new List<AdmissionForm>();
}
