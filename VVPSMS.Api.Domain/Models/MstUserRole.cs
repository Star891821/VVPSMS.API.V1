using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstUserRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<MstRoleGroup> MstRoleGroups { get; set; } = new List<MstRoleGroup>();
}
