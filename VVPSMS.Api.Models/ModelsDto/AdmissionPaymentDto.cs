using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class AdmissionPaymentDto
    {
        public int AdmissionpaymentId { get; set; }

        public int UserId { get; set; }

        public string Useremail { get; set; } = null!;

        public int Status { get; set; }

        public string ImageName { get; set; } = null!;

        public string ImagePath { get; set; } = null!;

        public string? FileContentsAsBase64 { get; set; } = null!;
        
        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
