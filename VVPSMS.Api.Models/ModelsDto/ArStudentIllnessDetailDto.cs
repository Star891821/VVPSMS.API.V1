
namespace VVPSMS.Api.Models.ModelsDto
{
    public class ArStudentIllnessDetailDto
    {
        public int ArstudentillnessdetailsId { get; set; }

        public int? ArformId { get; set; }

        public string? IllnessType { get; set; }

        public string? IllnessName { get; set; }

        public string? IllnessDate { get; set; }

        public string? IllnessDetails { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
