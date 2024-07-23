using Microsoft.EntityFrameworkCore;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Interfaces;
using StayConfirmed.BusinessLogic.Models.Stakeholder;

namespace StayConfirmed.BusinessLogic.Queries.StakeholderQueries.GetAllStakeholdersQuery;

public class GetAllStakeholdersQueryHandler(IApplicationDbContext context)
    : ICommandHandler<GetAllStakeholdersQueryRequest, GetAllStakeholdersQueryResponse>
{
    public async Task<GetAllStakeholdersQueryResponse> Handle(GetAllStakeholdersQueryRequest command)
    {
        try
        {
            var stakeholders = context.Stakeholders.AsQueryable();

            if (command.Id is not null)
            {
                stakeholders = stakeholders
                    .Where(x => x.IdStakeholder == command.Id);
            }

            bool anyStakeholders = await stakeholders.AnyAsync();

            if (!anyStakeholders)
            {
                return new GetAllStakeholdersQueryResponse
                {
                    Status = false,
                    Message = "No stakeholders in DB",
                    Code = 6,
                };
            }

            return new GetAllStakeholdersQueryResponse
            {
                Status = true,
                Message = "Stakeholders successfully retrived from DB",
                Code = 7,
                Data = GetAllStakeholderResponseModel.Convert(stakeholders)
            };
        }
        catch (Exception ex)
        {
            return new GetAllStakeholdersQueryResponse
            {
                Status = false,
                Message = ex.Message,
                Code = 8,
            };
        }
    }
}
