using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.StakeholderQueries.GetAllStakeholdersQuery;

public sealed class GetAllStakeholdersQueryRequest : ICommand<GetAllStakeholdersQueryResponse>
{
    public int? Id { get; set; }
}
