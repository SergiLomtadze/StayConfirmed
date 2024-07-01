using Microsoft.AspNetCore.Identity;
using StayConfirmed.Shared.Generators;

namespace StayConfirmed.DataAccess.Entities;

public class User : IdentityUser
{
    public int? IdProfile { get; set; } 
    public int? IdStakeholder { get; set; }
    public bool IsActive { get; set; }
    public string Secret { get; set; } = UniqueStringGenerator.GenerateUniqueString();
}
