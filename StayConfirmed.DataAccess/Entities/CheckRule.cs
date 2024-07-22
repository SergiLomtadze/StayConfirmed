using StayConfirmed.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class CheckRule
{
    [Key]
    public int IdCheckRule { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public int IdBrand { get; set; }
    public string Value { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public int HourBeforeCheck { get; set; }
    public PropertyType Type { get; set; }
}