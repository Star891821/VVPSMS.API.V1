using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class CommonResponse
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
    }
}
