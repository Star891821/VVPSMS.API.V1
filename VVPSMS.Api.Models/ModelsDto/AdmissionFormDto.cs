using System.ComponentModel.DataAnnotations;
using VVPSMS.Api.Models.CustomValidation;

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

        public int? AdmissionStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public StudentInfoDetailDto? StudentInfoDetails { get; set; }

        public List<FamilyOrGuardianInfoDetailDto>? listOfFamilyOrGuardianInfoDetails { get; set; }

        public List<SiblingInfoDto>? listofSiblingInfos { get; set; }

        public EmergencyContactDetailDto? EmergencyContactDetails { get; set; }

        public List<PreviousSchoolDetailDto>? listOfPreviousSchoolDetails { get; set; }

        public StudentHealthInfoDetailDto? StudentHealthInfoDetails { get; set; }

        public StudentIllnessDetailDto? StudentIllnessDetails { get; set; }

        public List<AdmissionEnquiryDetailDto>? listOfAdmissionEnquiryDetails { get; set; }

        public List<AdmissionDocumentDto>? listOfAdmissionDocuments { get; set; }

        public TransportDetailDto? TransportDetails { get; set; }

        public MstClassDto? ClassDetails { get; set; }

        public MstSchoolGradeDto? GradeDetails { get; set; }

        public MstSchoolStreamDto? StreamDetails { get; set; }

        public MstSchoolDto? SchoolDetails { get; set; }

    }
}
