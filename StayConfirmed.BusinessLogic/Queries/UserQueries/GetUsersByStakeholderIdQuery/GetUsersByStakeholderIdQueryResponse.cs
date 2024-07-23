using StayConfirmed.BusinessLogic.Models.User;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUsersByStakeholderIdQuery;

public class GetUsersByStakeholderIdQueryResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    public IEnumerable<UserResponseModel> Data { get; set; } = [];
}
