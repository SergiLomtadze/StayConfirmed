using StayConfirmed.DataAccess.Enums;

namespace StayConfirmed.DataAccess.Entities;

public class Stakeholder : BaseEntity
{
    public string BusinessName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Vat { get; set; }
    public StakeholderType StakeholderType { get; set; }
}