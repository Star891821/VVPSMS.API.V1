using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class Announcement
{
    public int PostId { get; set; }

    public string PostTitle { get; set; } = null!;

    public string PostDescription { get; set; } = null!;

    public int UserId { get; set; }

    public string Status { get; set; } = null!;

    public string? PostGroups { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual MstUser User { get; set; } = null!;
}
