using Microsoft.AspNetCore.Identity;
using StayConfirmed.Shared.Generators;

namespace StayConfirmed.DataAccess.Entities;

public class User : IdentityUser
{
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int? IdProfile { get; set; }
    public int? IdStakeholder { get; set; }
    public string Secret { get; set; } = UniqueStringGenerator.GenerateUniqueString();
}
