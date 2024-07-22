using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Interfaces;
using StayConfirmed.BusinessLogic.Models;
using StayConfirmed.BusinessLogic.Models.User;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserQuery;

public class GetUserQueryHandler(IApplicationDbContext context) 
    : ICommandHandler<GetUserQueryRequest, GetUserQueryResponse>
{
    public Task<GetUserQueryResponse> Handle(GetUserQueryRequest command)
    {
        var user = context.Users.Where(u => u.Email.Equals(command.Email)).FirstOrDefault();
        var result = new GetUserQueryResponse
        {
            Status = true,
            Message = "User data",
            Code = 2,
            Data = new UserModel
            {
                Secret = user.Secret,
                IsActive = user.IsActive
            }
        };

        return Task.FromResult(result);;
    }
}
