using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class Profile
{
    [Key]
    public int IdProfile { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
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
