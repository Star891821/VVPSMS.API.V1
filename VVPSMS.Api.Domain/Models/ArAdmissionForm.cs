using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class ArAdmissionForm
{
    public int ArformId { get; set; }

    public int? AcademicId { get; set; }

    public int? SchoolId { get; set; }

    public int? StreamId { get; set; }

    public int? GradeId { get; set; }

    public int? ClassId { get; set; }

    public int? AdmissionStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<ArAdmissionDocument> ArAdmissionDocuments { get; set; } = new List<ArAdmissionDocument>();

    public virtual ICollection<ArAdmissionEnquiryDetail> ArAdmissionEnquiryDetails { get; set; } = new List<ArAdmissionEnquiryDetail>();

    public virtual ICollection<ArEmergencyContactDetail> ArEmergencyContactDetails { get; set; } = new List<ArEmergencyContactDetail>();

    public virtual ICollection<ArFamilyOrGuardianInfoDetail> ArFamilyOrGuardianInfoDetails { get; set; } = new List<ArFamilyOrGuardianInfoDetail>();

    public virtual ICollection<ArPreviousSchoolDetail> ArPreviousSchoolDetails { get; set; } = new List<ArPreviousSchoolDetail>();

    public virtual ICollection<ArSiblingInfo> ArSiblingInfos { get; set; } = new List<ArSiblingInfo>();

    public virtual ICollection<ArStudentHealthInfoDetail> ArStudentHealthInfoDetails { get; set; } = new List<ArStudentHealthInfoDetail>();

    public virtual ICollection<ArStudentIllnessDetail> ArStudentIllnessDetails { get; set; } = new List<ArStudentIllnessDetail>();

    public virtual ICollection<ArStudentInfoDetail> ArStudentInfoDetails { get; set; } = new List<ArStudentInfoDetail>();

    public virtual ICollection<ArTransportDetail> ArTransportDetails { get; set; } = new List<ArTransportDetail>();
}
