using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Models.User;
using StayConfirmed.DataAccess.Entities;
using System.Text.Json;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.ResetPasswordCommand;

public class ResetPasswordCommandHandler(UserManager<User> userManager,
    IDataProtectionProvider protectionProvider) 
    : ICommandHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>
{
    private readonly IDataProtector _dataProtector = protectionProvider.CreateProtector("ForgotPassword");
    public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest command)
    {
        var stringFromToken = _dataProtector.Unprotect(command.Token);
        var jsonResult = JsonSerializer.Deserialize<ForgotPasswordToken>(stringFromToken);

        var user = await userManager.FindByEmailAsync(jsonResult.Email);
        if (user is null)
        {
            return new ResetPasswordCommandResponse
            {
                Status = false,
                Message = "User not found"
            };
        }

        var result = await userManager.ResetPasswordAsync(user, jsonResult.Token!, command.Password!);
        if (result.Succeeded)
        {
            return new ResetPasswordCommandResponse
            {
                Status = true,
                Message = "Password updated successfully"
            };
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description);
            return new ResetPasswordCommandResponse
            {
                Status = false,
                Message = string.Join(", ", errors)
            };
        }
    }
}
