using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class AdmissionForm
{
    public int FormId { get; set; }

    public int AcademicId { get; set; }

    public int SchoolCode { get; set; }

    public int StreamId { get; set; }

    public int GradeId { get; set; }

    public int ClassId { get; set; }

    public string StudentGivenName { get; set; } = null!;

    public string StudentSurname { get; set; } = null!;

    public DateTime StudentDob { get; set; }

    public string StudentGender { get; set; } = null!;

    public int StudentAge { get; set; }

    public string ParentName1 { get; set; } = null!;

    public string? HighestQualification1 { get; set; }

    public string ParentContact1 { get; set; } = null!;

    public string? ParentEmail1 { get; set; }

    public string? ParentName2 { get; set; }

    public string? HighestQualification2 { get; set; }

    public string? ParentContact2 { get; set; }

    public string? ParentEmail2 { get; set; }

    public string? PreferredContact { get; set; }

    public int Declaration { get; set; }

    public string SiblingsYn { get; set; } = null!;

    public int? SpecialNeeds { get; set; }

    public int? LearningDisabilities { get; set; }

    public string? PreviousSchool { get; set; }

    public string? ReasonDescription { get; set; }

    public int? StudentExpelled { get; set; }

    public string? DetailsExpulsion { get; set; }

    public int? AdmissionStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<AdmissionDocument> AdmissionDocuments { get; set; } = new List<AdmissionDocument>();

    public virtual MstClass Class { get; set; } = null!;

    public virtual MstSchoolGrade Grade { get; set; } = null!;

    public virtual ICollection<SiblingInfo> SiblingInfos { get; set; } = new List<SiblingInfo>();

    public virtual MstSchoolStream Stream { get; set; } = null!;
}
