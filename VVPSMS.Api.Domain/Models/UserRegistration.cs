using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class UserRegistration
{
    public int RegisterId { get; set; }

    public string? RegisterEmail { get; set; }

    public string RegisterGivenname { get; set; } = null!;

    public string RegisterSurname { get; set; } = null!;

    public string RegisterPassword { get; set; } = null!;

    public string? RegisterPhone { get; set; }

    public string RegisterType { get; set; } = null!;

    public int Enforce2Fa { get; set; }

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
