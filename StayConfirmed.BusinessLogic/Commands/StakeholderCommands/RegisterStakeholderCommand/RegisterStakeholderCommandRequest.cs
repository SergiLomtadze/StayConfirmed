using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Commands.RegistrationCommands.RegisterCommand;

public class RegisterStakeholderCommandRequest : ICommand<RegisterStakeholderCommandResponse>
{
    public string StakeholderName { get; set; }
    public string Vat { get; set; }
    public string Phone { get; set; }
    public string StakeholderEmail { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string Region { get; set; }
    public string Province { get; set; }
}
