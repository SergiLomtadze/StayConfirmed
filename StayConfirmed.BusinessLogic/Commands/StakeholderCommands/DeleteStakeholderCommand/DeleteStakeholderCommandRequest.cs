using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Commands.StakeholderCommands.DeleteStakeholderCommand;

public class DeleteStakeholderCommandRequest : ICommand<DeleteStakeholderCommandResponse>
{
    public string Vat { get; set; }
}
