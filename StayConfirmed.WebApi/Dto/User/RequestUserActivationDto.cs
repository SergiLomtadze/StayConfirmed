using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.WebApi.Dto.User;

public class RequestUserActivationDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Path { get; set; }
}
