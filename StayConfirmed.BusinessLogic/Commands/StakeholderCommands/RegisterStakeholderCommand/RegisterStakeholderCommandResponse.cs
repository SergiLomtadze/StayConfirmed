using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.BusinessLogic.Commands.RegistrationCommands.RegisterCommand;

public class RegisterStakeholderCommandResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    public Stakeholder Stakeholder { get; set; }
}
