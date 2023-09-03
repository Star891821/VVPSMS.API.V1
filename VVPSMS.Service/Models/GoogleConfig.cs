using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Service.Models
{
    public class GoogleConfig
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string RedirectUri { get; set; }
        public string TokenUrl { get; set; }
        public string GraphUrl { get; set; }
    }
}
