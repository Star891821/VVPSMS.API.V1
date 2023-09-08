using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Userpassword { get; set; } = null!;

    public string UserGivenName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string? UserPhone { get; set; }

    public string UserRole { get; set; } = null!;

    public string UserLoginType { get; set; } = null!;

    public int Enforce2Fa { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? LastloginAt { get; set; }

    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
}
