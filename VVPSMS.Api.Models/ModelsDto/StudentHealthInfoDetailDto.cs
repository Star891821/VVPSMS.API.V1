
namespace VVPSMS.Api.Models.ModelsDto
{
    public class StudentHealthInfoDetailDto
    {
        public int StudenthealthinfodetailsId { get; set; }
 
        public int? FormId { get; set; }

        public string ChildName { get; set; } = null!;

        public string Class { get; set; } = null!;

        public string BloodGroup { get; set; } = null!;

        public string? VisionLeft { get; set; }

        public string? VisionRight { get; set; }

        public string Height { get; set; } = null!;

        public string? Weight { get; set; }

        public string ImmunizationStatus { get; set; } = null!;

        public string? IdentificationMarks { get; set; }

        public string? RegularmedicineTakenbystudent { get; set; }

        public string? HealthHistory { get; set; }

        public string? AllergiesIfAny { get; set; }

        public string? SpecialNeeds { get; set; }

        public string? LearningDisabilities { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
