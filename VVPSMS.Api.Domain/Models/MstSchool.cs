using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstSchool
{
    public int SchoolId { get; set; }

    public string SchoolName { get; set; } = null!;

    public string SchoolCode { get; set; } = null!;

    public string SchoolDescription { get; set; } = null!;

    public string SchoolAddress1 { get; set; } = null!;

    public string? SchoolAddress2 { get; set; }

    public string? SchoolLogopath { get; set; }

    public string SchoolPhone { get; set; } = null!;

    public string? SchoolWebsite { get; set; }

    public string? SchoolCoordinates { get; set; }

    public string SchoolLandmark { get; set; } = null!;

    public string SchoolDistrict { get; set; } = null!;

    public string SchoolState { get; set; } = null!;

    public string SchoolCountry { get; set; } = null!;

    public string? StreamsAvailable { get; set; }

    public string? GradesAvailable { get; set; }

    public string? ClassesAvailable { get; set; }

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
