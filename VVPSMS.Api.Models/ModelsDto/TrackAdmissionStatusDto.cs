using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class TrackAdmissionStatusDto
    {
        public int TrackId { get; set; }

        public int? FormId { get; set; }

        public int? AdmissionStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }
    }
}
