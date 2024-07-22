using StayConfirmed.BusinessLogic.Models.User;

namespace StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserQuery;

public class GetUserQueryResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    public UserModel Data { get; set; }
}
