using Microsoft.EntityFrameworkCore;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Interfaces;

namespace StayConfirmed.BusinessLogic.Commands.RegistrationCommands.RegisterCommand;

public class RegisterStakeholderCommandHandler(IApplicationDbContext context) 
    : ICommandHandler<RegisterStakeholderCommandRequest, RegisterStakeholderCommandResponse>
{
    public async Task<RegisterStakeholderCommandResponse> Handle(RegisterStakeholderCommandRequest command)
    {
        var existingStakeholder = await context
            .Stakeholders
            .Where(x => x.Vat.Equals(command.Vat))
            .FirstOrDefaultAsync();

        if (existingStakeholder != null)
        {
            return new RegisterStakeholderCommandResponse
            {
                Status = false,
                Message = $"Stakeholder with VAT {command.Vat} already exist"
            };
        }

        context.Stakeholders.Add(new DataAccess.Entities.Stakeholder
        {
            Name = command.StakeholderName,
            Vat = command.Vat,
            Email = command.StakeholderEmail,
            Phone = command.Phone,
            Address = command.Address,
            City = command.City,
            Zip = command.Zip,
            Region = command.Region,
            Province = command.Province,
            StakeholderType = DataAccess.Enums.StakeholderType.Customer,
        });

        context.SaveChanges();

        return new RegisterStakeholderCommandResponse
        {
            Status = true,
            Stakeholder = context
                .Stakeholders
                .Where(x => x.Vat.Equals(command.Vat))
                .FirstOrDefault(),
            Message = $"Stakeholder with VAT {command.Vat} registered successfully"
        };
    }
}
