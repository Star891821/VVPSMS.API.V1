using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VVPSMS.Api.Models.CustomValidation;
using VVPSMS.Api.Models.Enums;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class ArAdmissionFormDto
    {
        [Key]
        public int ArformId { get; set; }

        public int? AcademicId { get; set; }

        public int? SchoolId { get; set; }

        public int? StreamId { get; set; }

        public int? GradeId { get; set; }

        public int? ClassId { get; set; }

        public object? AdmissionStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual List<ArAdmissionDocumentDto> ArAdmissionDocuments { get; set; }

        public virtual List<ArAdmissionEnquiryDetailDto> ArAdmissionEnquiryDetails { get; set; } 

        public virtual List<ArEmergencyContactDetailDto> ArEmergencyContactDetails { get; set; }

        public virtual List<ArFamilyOrGuardianInfoDetailDto> ArFamilyOrGuardianInfoDetails { get; set; }

        public virtual List<ArPreviousSchoolDetailDto> ArPreviousSchoolDetails { get; set; } 

        public virtual List<ArSiblingInfoDto> ArSiblingInfos { get; set; } 

        public virtual List<ArStudentHealthInfoDetailDto> ArStudentHealthInfoDetails { get; set; }

        public virtual List<ArStudentIllnessDetailDto> ArStudentIllnessDetails { get; set; } 

        public virtual List<ArStudentInfoDetailDto> ArStudentInfoDetails { get; set; } 

        public virtual List<ArTransportDetailDto> ArTransportDetails { get; set; }

    }
}
