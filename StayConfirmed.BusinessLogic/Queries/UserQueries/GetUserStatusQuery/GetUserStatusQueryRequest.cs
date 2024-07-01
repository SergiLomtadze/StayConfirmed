using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserStatusQuery;

public sealed record GetUserStatusQueryRequest : ICommand<GetUserStatusQueryResponse>
{
}