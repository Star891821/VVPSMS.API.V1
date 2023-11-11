
namespace VVPSMS.Api.Models.ModelsDto
{
    public class TransportDetailDto
    {
        public int TransportdetailsId { get; set; }

        public int? FormId { get; set; }

        public DateTime? DateofApplication { get; set; }

        public string? NameofStudent { get; set; }

        public string? AdmittedTo { get; set; }

        public string? FatherName { get; set; }

        public string? FatherPhone { get; set; }

        public string? FatherEmail { get; set; }

        public string? MotherName { get; set; }

        public string? MotherPhone { get; set; }

        public string? MotherEmail { get; set; }

        public string? Address { get; set; }

        public string? LandMark { get; set; }

        public string? PreferredPickupPoint { get; set; }

        public string? PreferredDropPoint { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? Academicid { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
