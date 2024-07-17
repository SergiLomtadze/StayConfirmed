using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.WebApi.Dto.Registration;

public class RegisterDto
{
    [Required(ErrorMessage = "Company Name is required")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "VAT is required")]
    public string Vat { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string CompanyEmail { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "City is required")]
    public string City { get; set; }

    public string Zip { get; set; }

    public string Region { get; set; }

    public string Province { get; set; }


    [Required(ErrorMessage = "User Name is required")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "User SurName is required")]
    public string UserSurname { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string UserEmail { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    public string ConfirmPassword { get; set; }
}
