﻿using System;
using System.Collections.Generic;

namespace VVPSMS.API.Models;

public partial class TransportDetail
{
    public int TransportdetailsId { get; set; }

    public int? FormId { get; set; }

    public DateTime? AcademicYear { get; set; }

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

    public int CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual AdmissionForm? Form { get; set; }
}