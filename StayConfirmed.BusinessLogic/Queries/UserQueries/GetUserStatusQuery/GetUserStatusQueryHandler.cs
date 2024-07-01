using Microsoft.AspNetCore.Http;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Interfaces;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserStatusQuery;

public class GetUserStatusQueryHandler(IApplicationDbContext context,
    IHttpContextAccessor contextAccessor) 
    : ICommandHandler<GetUserStatusQueryRequest, GetUserStatusQueryResponse>
{
    public Task<GetUserStatusQueryResponse> Handle(GetUserStatusQueryRequest command)
    {
        var userEmail = contextAccessor.HttpContext.User.Identity.Name;
        var userStatus  = context.Users
            .Where(u => u.Email.Equals(userEmail))
            .Select(u => u.IsActive)
        .FirstOrDefault();

        var result = new GetUserStatusQueryResponse
        {
            IsActive = userStatus
        };

        return Task.FromResult(result);
    }
}
