using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.ActivateUserCommands;

public sealed record ActivateUserCommandRequest : ICommand<ActivateUserCommandResponse>
{
    public string Token { get; set; }
}