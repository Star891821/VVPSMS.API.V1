using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstRoleGroup
{
    public int RolegroupId { get; set; }

    public string RolegroupName { get; set; } = null!;

    public string? RolegroupDescription { get; set; }

    public int RoleId { get; set; }

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual MstUserRole Role { get; set; } = null!;
}
