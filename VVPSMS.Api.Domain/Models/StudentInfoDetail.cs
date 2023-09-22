using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class StudentInfoDetail
{
    public int StudentinfoId { get; set; }

    public int FormId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Dob { get; set; } = null!;

    public string DobInWords { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public string? Religion { get; set; }

    public string? Caste { get; set; }

    public string AadharNumber { get; set; } = null!;

    public string? SatsChildNumber { get; set; }

    public string? UDiseCode { get; set; }

    public string? PassportNumber { get; set; }

    public DateTime? DateOfIssue { get; set; }

    public DateTime? DateOfExpiry { get; set; }

    public string? PermanentAddress { get; set; }

    public string? StudentLivesWith { get; set; }

    public string? TypeofFamily { get; set; }

    public int? NoOfFamilymembers { get; set; }

    public string? MotherTongue { get; set; }

    public string? OtherKnownLanguages { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual AdmissionForm Form { get; set; } = null!;
}
