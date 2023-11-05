using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class ArTransportDetail
{
    public int ArtransportdetailsId { get; set; }

    public int? ArformId { get; set; }

    public DateTime? DateofApplication { get; set; }

    public string? NameofStudent { get; set; }

    public string? AdmittedTo { get; set; }

    public string? FatherName { get; set; }

    public int? FatherPhone { get; set; }

    public string? FatherEmail { get; set; }

    public string? MotherName { get; set; }

    public int? MotherPhone { get; set; }

    public string? MotherEmail { get; set; }

    public string? Address { get; set; }

    public string? LandMark { get; set; }

    public string? PreferredPickupPoint { get; set; }

    public string? PreferredDropPoint { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public int? Academicid { get; set; }

    public virtual ArAdmissionForm? Arform { get; set; }
}
