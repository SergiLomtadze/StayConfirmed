using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.UserActivationCommand;

public sealed record UserActivationCommandRequest : ICommand<UserActivationCommandResponse>
{
    public string Email { get; set; }
}