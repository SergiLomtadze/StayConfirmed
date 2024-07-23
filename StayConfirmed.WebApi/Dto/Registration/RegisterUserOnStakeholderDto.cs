using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.WebApi.Dto.Registration;

public class RegisterUserOnStakeholderDto
{

    [Required(ErrorMessage = "StakeholderId is required")]
    public int StakeholderId { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "User SurName is required")]
    public string UserSurname { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string UserEmail { get; set; }

    public string Password { get; set; }
}
