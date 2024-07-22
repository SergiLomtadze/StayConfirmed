using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.WebApi.Dto.UserDto;

public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
