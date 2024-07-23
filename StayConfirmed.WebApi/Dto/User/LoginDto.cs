namespace StayConfirmed.WebApi.Dto.User
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
