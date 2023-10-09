using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class AdmissionForm
{
    public int FormId { get; set; }

    public int AcademicId { get; set; }

    public int SchoolId { get; set; }

    public int StreamId { get; set; }

    public int GradeId { get; set; }

    public int ClassId { get; set; }

    public int? AdmissionStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<AdmissionDocument> AdmissionDocuments { get; set; } = new List<AdmissionDocument>();

    public virtual ICollection<AdmissionEnquiryDetail> AdmissionEnquiryDetails { get; set; } = new List<AdmissionEnquiryDetail>();

    public virtual ICollection<EmergencyContactDetail> EmergencyContactDetails { get; set; } = new List<EmergencyContactDetail>();

    public virtual ICollection<FamilyOrGuardianInfoDetail> FamilyOrGuardianInfoDetails { get; set; } = new List<FamilyOrGuardianInfoDetail>();

    public virtual ICollection<PreviousSchoolDetail> PreviousSchoolDetails { get; set; } = new List<PreviousSchoolDetail>();

    public virtual ICollection<SiblingInfo> SiblingInfos { get; set; } = new List<SiblingInfo>();

    public virtual ICollection<StudentHealthInfoDetail> StudentHealthInfoDetails { get; set; } = new List<StudentHealthInfoDetail>();

    public virtual ICollection<StudentIllnessDetail> StudentIllnessDetails { get; set; } = new List<StudentIllnessDetail>();

    public virtual ICollection<StudentInfoDetail> StudentInfoDetails { get; set; } = new List<StudentInfoDetail>();

    public virtual ICollection<TransportDetail> TransportDetails { get; set; } = new List<TransportDetail>();
}
