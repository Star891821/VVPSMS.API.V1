using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class FamilyOrGuardianInfoDetail
{
    public int FamilyorguardianinfodetailsId { get; set; }

    public int? FormId { get; set; }

    public bool? Legalguardian { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string? HighestQualification { get; set; }

    public string? Occupation { get; set; }

    public string? DesignationNameofcompany { get; set; }

    public decimal AnnualIncome { get; set; }

    public string? OfficeAddress { get; set; }

    public string AadharNumber { get; set; } = null!;

    public string? PanNumber { get; set; }

    public string? Passportnumber { get; set; }

    public DateTime? Passportissuedate { get; set; }

    public DateTime? Passportexpirydate { get; set; }

    public string? Contact { get; set; }

    public string Email { get; set; } = null!;

    public string? Preferredcontact { get; set; }

    public string? Relationshiptype { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual AdmissionForm? Form { get; set; }
}
