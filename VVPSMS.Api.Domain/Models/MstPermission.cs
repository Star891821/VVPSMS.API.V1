using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstPermission
{
    public int PermissionId { get; set; }

    public string PermissionName { get; set; } = null!;

    public string PermissionDetails { get; set; } = null!;

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<RolePermissionsMapping> RolePermissionsMappings { get; set; } = new List<RolePermissionsMapping>();
}
