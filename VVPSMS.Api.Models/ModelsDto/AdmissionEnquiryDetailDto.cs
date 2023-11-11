
using System.ComponentModel.DataAnnotations;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class AdmissionEnquiryDetailDto
    {
        public int AdmissionenquirydetailsId { get; set; }

        public int? FormId { get; set; }

        public int? MstenquiryquestiondetailsId { get; set; }

        public string? EnquiryResponse { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
