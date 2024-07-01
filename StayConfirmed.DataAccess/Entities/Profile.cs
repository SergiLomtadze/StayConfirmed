namespace StayConfirmed.DataAccess.Entities;

public class Profile : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<int> IdRoles { get; set; } = [];

    public void AddRole(int roleId)
    {
        IdRoles.Add(roleId);
    }

    public void AddRoles(IEnumerable<int> roleIds)
    {
        foreach (var roleId in roleIds)
        {
            AddRole(roleId);
        }
    }

    public void RemoveRoles()
    {
        IdRoles.Clear();
    }
}
