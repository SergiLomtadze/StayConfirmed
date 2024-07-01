using Microsoft.AspNetCore.DataProtection;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Interfaces;
using StayConfirmed.BusinessLogic.Models.User;
using System.Text.Json;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.ActivateUserCommands;

public class ActivateUserCommandHandler(IDataProtectionProvider protectionProvider,
    IApplicationDbContext context)
    : ICommandHandler<ActivateUserCommandRequest, ActivateUserCommandResponse>
{
    private readonly IDataProtector _dataProtector = protectionProvider.CreateProtector("UserActivation");
    public Task<ActivateUserCommandResponse> Handle(ActivateUserCommandRequest command)
    {
        var stringFromToken = _dataProtector.Unprotect(command.Token);
        var jsonResult = JsonSerializer.Deserialize<UserActivationToken>(stringFromToken);

        var user = context.Users
            .Where(u => u.Email.Equals(jsonResult.Email))
            .FirstOrDefault();

        user.IsActive = true;
        context.Users.Update(user);
        context.SaveChanges();

        return Task.FromResult(new ActivateUserCommandResponse());
    }
}