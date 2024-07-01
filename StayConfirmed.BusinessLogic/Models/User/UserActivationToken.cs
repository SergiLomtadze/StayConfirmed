namespace StayConfirmed.BusinessLogic.Models.User;

public class UserActivationToken
{
    public string Email { get; set; }
    public DateTime GenerationTime { get; set; }
}
