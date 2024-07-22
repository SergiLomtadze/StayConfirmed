using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class PropertyProviderMapper
{
    [Key]
    public int IdPropertyProviderMapper { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public int IdProperty { get; set; }
    public int IdStakeholder { get; set; }
}