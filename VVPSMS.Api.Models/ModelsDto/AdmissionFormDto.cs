using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VVPSMS.Api.Models.CustomValidation;
using VVPSMS.Api.Models.Enums;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class AdmissionFormDto
    {
        [Key]
        public int FormId { get; set; }

        public int AcademicId { get; set; }

        public int SchoolId { get; set; }

        public int StreamId { get; set; }

        public int GradeId { get; set; }

        public int ClassId { get; set; }

        public AdmissionStatusDto AdmissionStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual List<AdmissionDocumentDto> listOfAdmissionDocuments { get; set; }

        public virtual List<AdmissionEnquiryDetailDto> AdmissionEnquiryDetails { get; set; } 

        public virtual List<EmergencyContactDetailDto> EmergencyContactDetails { get; set; }

        public virtual List<FamilyOrGuardianInfoDetailDto> FamilyOrGuardianInfoDetails { get; set; }

        public virtual List<PreviousSchoolDetailDto> PreviousSchoolDetails { get; set; } 

        public virtual List<SiblingInfoDto> SiblingInfos { get; set; } 

        public virtual List<StudentHealthInfoDetailDto> StudentHealthInfoDetails { get; set; }

        public virtual List<StudentIllnessDetailDto> StudentIllnessDetails { get; set; } 

        public virtual List<StudentInfoDetailDto> StudentInfoDetails { get; set; } 

        public virtual List<TransportDetailDto> TransportDetails { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!Enum.TryParse(typeof(AdmissionStatusDto), true, out AdmissionStatusDto result))
        //    {
        //        yield return new ValidationResult("Invalid address type", new[] { nameof(AdmissionStatusDto) });
        //    }

        //    AdmissionStatusDto = result.ToString(); //normalize Type
        //}
    }
}
