using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class Currency
{
    [Key]
    public int IdCurrency { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
