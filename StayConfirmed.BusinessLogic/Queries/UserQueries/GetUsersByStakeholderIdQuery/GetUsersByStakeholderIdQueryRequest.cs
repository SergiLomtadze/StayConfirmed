using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUsersByStakeholderIdQuery;

public class GetUsersByStakeholderIdQueryRequest : ICommand<GetUsersByStakeholderIdQueryResponse>
{
    public int StakeholderId { get; set; }
}
