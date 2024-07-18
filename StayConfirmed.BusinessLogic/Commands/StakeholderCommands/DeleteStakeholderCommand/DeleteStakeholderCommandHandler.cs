using Microsoft.EntityFrameworkCore;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Interfaces;

namespace StayConfirmed.BusinessLogic.Commands.StakeholderCommands.DeleteStakeholderCommand;

public class DeleteStakeholderCommandHandler(IApplicationDbContext context) 
    : ICommandHandler<DeleteStakeholderCommandRequest, DeleteStakeholderCommandResponse>
{
    public async Task<DeleteStakeholderCommandResponse> Handle(DeleteStakeholderCommandRequest command)
    {
        try
        {
            var stakeholder = await context.Stakeholders
                .FirstOrDefaultAsync(x => x.Vat.Equals(command.Vat));

            if (stakeholder != null)
            {
                context.Stakeholders.Remove(stakeholder);
                await context.SaveChangesAsync();
            }

            return new DeleteStakeholderCommandResponse
            {
                Status = true,
                Message = "Removed successfully"
            };
        }
        catch (Exception ex)
        {
            return new DeleteStakeholderCommandResponse
            {
                Status = false,
                Message = ex.Message,
            };
        }
    }
}
