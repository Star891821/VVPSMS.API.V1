namespace VVPSMS.Api.Models.ModelsDto
{
    public class MstSchoolGradeDto
    {
        public int GradeId { get; set; }

        public string GradeName { get; set; } = null!;

        public int ActiveYn { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
