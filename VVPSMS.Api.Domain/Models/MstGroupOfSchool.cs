using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstGroupOfSchool
{
    public int GroupofSchoolsId { get; set; }

    public string GroupofSchoolsName { get; set; } = null!;

    public string GroupofSchoolsCode { get; set; } = null!;

    public string? GroupofSchoolsLogo { get; set; }

    public string GroupAddress { get; set; } = null!;

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
