using StayConfirmed.BusinessLogic.Models.Stakeholder;

namespace StayConfirmed.WebApi.Dto.Registration;

public class RegisterUserOnStakeholderResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
}
