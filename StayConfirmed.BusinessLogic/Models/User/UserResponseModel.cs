namespace StayConfirmed.BusinessLogic.Models.User;

public class UserResponseModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public static IEnumerable<UserResponseModel> Convert(IEnumerable<DataAccess.Entities.User> users)
    {
        List<UserResponseModel> responses = [];
        foreach (var user in users)
        {
            responses.Add(new UserResponseModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
            });
        }

        return responses;
    }
}