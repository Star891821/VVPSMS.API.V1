namespace VVPSMS.Api.Models.ModelsDto
{
    public class LoginResponseDto:CommonResponse
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public bool Status { get; set; }

        public int Id { get; set; }

        public string email { get; set; }
        //public string UserName { get; set; }

        //public string GivenName { get; set; }

        //public string SurName { get; set; }

        //public string Phone { get; set; }

        //public string Role { get; set; }
    }
}
