using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.ResetPasswordCommand;

public sealed record ResetPasswordCommandRequest : ICommand<ResetPasswordCommandResponse>
{
    public string Token { get; set; }
    public string Password { get; set; }
}
