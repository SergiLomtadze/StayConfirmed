using Microsoft.EntityFrameworkCore;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Interfaces;
using StayConfirmed.BusinessLogic.Models.User;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUsersByStakeholderIdQuery;

public class GetUsersByStakeholderIdQueryHandler(IApplicationDbContext context)
    : ICommandHandler<GetUsersByStakeholderIdQueryRequest, GetUsersByStakeholderIdQueryResponse>
{
    public async Task<GetUsersByStakeholderIdQueryResponse> Handle(GetUsersByStakeholderIdQueryRequest command)
    {
        try
        {
            var users = context.Users
                .Where(x => x.IsActive)
                .Where(x => x.IdStakeholder == command.StakeholderId)
                .AsQueryable();

            bool anyUsers = await users.AnyAsync();

            if (!anyUsers)
            {
                return new GetUsersByStakeholderIdQueryResponse
                {
                    Status = false,
                    Message = $"No active users wiht this ({command.StakeholderId}) stakeholder id in DB",
                    Code = 9,
                };
            }

            return new GetUsersByStakeholderIdQueryResponse
            {
                Status = true,
                Message = "Users successfully retrived from DB",
                Code = 10,
                Data = UserResponseModel.Convert(users)
            };
        }
        catch (Exception ex)
        {
            return new GetUsersByStakeholderIdQueryResponse
            {
                Status = false,
                Message = ex.Message,
                Code = 11,
            };
        }
    }
}
