using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.Logger
{
    public class LogsDto
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public string? Level { get; set; }

        public string? Message { get; set; }

        public string? StackTrace { get; set; }

        public string? Exception { get; set; }

        public string? Logger { get; set; }

        public string? Url { get; set; }
        //public string? FormId { get; set; }
    }
}
