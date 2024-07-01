using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserQuery;

public sealed record GetUserQueryRequest : ICommand<GetUserQueryResponse>
{
    public string Email { get; set; }
}