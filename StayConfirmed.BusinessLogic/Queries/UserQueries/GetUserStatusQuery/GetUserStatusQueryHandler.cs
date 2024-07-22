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

        var result = new GetUserStatusQueryResponse();
        if (userStatus)
        {
            result.Status = userStatus;
            result.Message = "User is active";
            result.Code = 0;
        }
        else 
        {
            result.Status = userStatus;
            result.Message = "User is not active";
            result.Code = 1;
        }

        return Task.FromResult(result);
    }
}
