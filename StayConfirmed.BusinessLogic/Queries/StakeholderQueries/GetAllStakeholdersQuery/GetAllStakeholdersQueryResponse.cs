using StayConfirmed.BusinessLogic.Models.Stakeholder;

namespace StayConfirmed.BusinessLogic.Queries.StakeholderQueries.GetAllStakeholdersQuery;

public class GetAllStakeholdersQueryResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    public IEnumerable<GetAllStakeholderResponseModel> Data { get; set; } = [];
}
