using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class MstUserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Userpassword { get; set; } = null!;

        public string UserGivenName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;

        public string? UserPhone { get; set; }

        public int RoleId { get; set; }

        public string UserLoginType { get; set; } = null!;


    }
}
