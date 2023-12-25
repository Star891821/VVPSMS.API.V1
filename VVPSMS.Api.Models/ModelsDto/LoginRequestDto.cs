namespace VVPSMS.Api.Models.ModelsDto
{
    public class LoginRequestDto
    {
        public int Id { get; set; }

        public string name { get; set; } = null!;

        public string Password { get; set; }

        public string LoginUser { get; set; }

        public int RoleId { get; set; }

        public string UserType { get; set; }

        public string? Phone { get; set; }

        public string? email { get; set; }

        public int Enforce2Fa { get; set; }

        //public string UserId { get; set; }
        //public string name { get; set; } = null!;
        //public string Password { get; set; }

        //public string LoginUser { get; set; }

        //public int RoleId { get; set; }

        //public string UserType { get; set; }

        //public string UserGivenName { get; set; } = null!;

        //public string UserSurname { get; set; } = null!;

        //public string? Phone { get; set; }

        //public string? email { get; set; }

        //public int Enforce2Fa { get; set; }

    }

}
