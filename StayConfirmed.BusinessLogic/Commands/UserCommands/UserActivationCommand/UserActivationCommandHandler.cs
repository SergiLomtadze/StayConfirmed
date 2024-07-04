using Microsoft.AspNetCore.DataProtection;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Models.User;
using System.Text;
using System.Text.Json;

namespace StayConfirmed.BusinessLogic.Commands.UserCommands.UserActivationCommand;

public class UserActivationCommandHandler(IDataProtectionProvider protectionProvider)
        : ICommandHandler<UserActivationCommandRequest, UserActivationCommandResponse>
{
    private readonly IDataProtector _dataProtector = protectionProvider.CreateProtector("UserActivation");

    public Task<UserActivationCommandResponse> Handle(UserActivationCommandRequest command)
    {
        var tokenData = new UserActivationToken
        {
            Email = command.Email,
            GenerationTime = DateTime.Now
        };

        var token = _dataProtector.Protect(JsonSerializer.Serialize(tokenData));

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
                Subject = "Stayconfirmed User Activation",
                Body = UserActivatioEmailBody(token),
                isBodyHtml = true,
                Smtp = "15",
            };
            var mailClient = new Mailer.MailerClient();

            var result = mailClient.SendMailAsync(_Mail).Result;

            var res = new UserActivationCommandResponse();
            if (result.Equals("S"))
            {
                res.Status = true;
                res.Message = "Activation Mail Sent";
            }
            if (result.Equals("E"))
            {
                res.Status = false;
                res.Message = "Invalid email";
            }
            return Task.FromResult(res);
        }
        catch (Exception ex)
        {
            var res = new UserActivationCommandResponse();
            res.Status = false;
            res.Message = ex.Message;
            return Task.FromResult(res);
        }
    }

    private string UserActivatioEmailBody(string token)
    {
        string page = "https://localhost:7195/api/User/ActivateUser";

        var result = new StringBuilder();

        result.Append($"<h2 style='text-align: center;'> To activate user please go to link:<a href=\"{page}?token={token}\"> {page} </a> </h2>");

        return result.ToString();
    }
}
