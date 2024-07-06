using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.ForgotPassowrdCommand;

public sealed record ForgotPasswordCommandRequest : ICommand<ForgotPasswordCommandResponse>
{
    public string Email { get; set; }
}
