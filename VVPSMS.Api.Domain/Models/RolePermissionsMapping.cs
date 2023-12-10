using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class RolePermissionsMapping
{
    public int MappingId { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual MstPermission Permission { get; set; } = null!;

    public virtual MstUserRole Role { get; set; } = null!;
}
