using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Models.User;
using StayConfirmed.DataAccess.Entities;
using System.Text;
using System.Text.Json;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.ForgotPassowrdCommand;

public class ForgotPasswordCommandHandler(UserManager<User> userManager,
    IDataProtectionProvider protectionProvider) 
    : ICommandHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
{
    private readonly IDataProtector _dataProtector = protectionProvider.CreateProtector("ForgotPassword");
    public async Task<ForgotPasswordCommandResponse> Handle(ForgotPasswordCommandRequest command)
    {
        var user = await userManager.FindByEmailAsync(command.Email);
        if (user is null)
        {
            return new ForgotPasswordCommandResponse
            {
                Status = false,
                Message = "User not found"
            };
        }

        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        var tokenData = new ForgotPasswordToken
        {
            Email = command.Email,
            Token = token
        };

        var forgotPasswordToken = _dataProtector.Protect(JsonSerializer.Serialize(tokenData));
        try
        {
            var from = new Mailer.MailAddress() { Email = "check@stayconfirmed.com" };
            List<string> toList = [];
            toList.Add(command.Email);
            var to = toList.ConvertAll(m => new Mailer.MailAddress() { Email = m })
                .ToArray();

            var _Mail = new Mailer.Mail()
            {
                From = from,
                To = to,
                Subject = "Stayconfirmed User Password Reset",
                Body = ForgotPassowrdEmailBody(forgotPasswordToken),
                isBodyHtml = true,
                Smtp = "15",
            };
            var mailClient = new Mailer.MailerClient();

            var result = mailClient.SendMailAsync(_Mail).Result;

            var res = new ForgotPasswordCommandResponse();
            if (result.Equals("S"))
            {
                res.Status = true;
                res.Message = "Forgot Password Mail Sent";
            }
            if (result.Equals("E"))
            {
                res.Status = false;
                res.Message = "Invalid email";
            }
            return res;
        }
        catch (Exception ex)
        {
            var res = new ForgotPasswordCommandResponse();
            res.Status = false;
            res.Message = ex.Message;
            return res;
        }
    }
    private string ForgotPassowrdEmailBody(string token)
    {
        string page = "https://localhost:7195/api/User/ActivateUser";

        var result = new StringBuilder();

        result.Append($"<h2 style='text-align: center;'> To reset password please go to link:<a href=\"{page}?token={token}\"> {page} </a> </h2>");

        return result.ToString();
    }
}
