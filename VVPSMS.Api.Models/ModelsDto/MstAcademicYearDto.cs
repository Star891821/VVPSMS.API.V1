
namespace VVPSMS.Api.Models.ModelsDto
{
    public class MstAcademicYearDto
    {
        public int AcademicId { get; set; }

        public string AcademicyearName { get; set; } = null!;

        public DateTime AcademicyearFrom { get; set; }

        public DateTime AcademicyearTo { get; set; }

        public string AcademictermNo { get; set; } = null!;

        public DateTime AcademicStartdate { get; set; }

        public DateTime AcademicEnddate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
