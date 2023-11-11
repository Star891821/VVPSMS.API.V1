
namespace VVPSMS.Api.Models.ModelsDto
{
    public class PreviousSchoolDetailDto
    {
        public int PreviousschooldetailsId { get; set; }

        public int? FormId { get; set; }

        public string? NameSchool { get; set; }

        public string? Address { get; set; }

        public string? Curriculum { get; set; }

        public string? ClassCompleted { get; set; }

        public DateTime? DateOfLeavingschool { get; set; }

        public string? YearsAttended { get; set; }

        public string? MediumofInstruction { get; set; }

        public string? ReasonForleaving { get; set; }

        public string? HasapplicanteverExpelledorsuspended { get; set; }

        public string? Reasonforsuspension { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
