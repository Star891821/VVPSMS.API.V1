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

        [Required(ErrorMessage = "Please enter name")]
        public string StudentGivenName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter surname")]
        public string StudentSurname { get; set; } = null!;
       
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
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

        public List<AdmissionDocumentDto>? listOfAdmissionDocuments { get; set; }

        public MstClassDto? ClassDetails { get; set; }

        public MstSchoolGradeDto? GradeDetails { get; set; }

        public List<SiblingInfoDto>? SiblingInfos { get; set; }

        public MstSchoolStreamDto? StreamDetails { get; set; }

        public MstSchoolDto? SchoolDetails { get; set; }

    }
}
