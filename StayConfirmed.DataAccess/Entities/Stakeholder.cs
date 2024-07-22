using StayConfirmed.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class Stakeholder
{
    [Key]
    public int IdStakeholder { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Vat { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string Region { get; set; }
    public string Province { get; set; }
    public StakeholderType StakeholderType { get; set; }
}