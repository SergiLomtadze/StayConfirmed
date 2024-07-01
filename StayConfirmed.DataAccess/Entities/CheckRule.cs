using StayConfirmed.DataAccess.Enums;

namespace StayConfirmed.DataAccess.Entities;

public class CheckRule : BaseEntity
{
    public int IdBrand { get; set; }
    public string Value { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public int HourBeforeCheck { get; set; }
    public PropertyType Type { get; set; }
}