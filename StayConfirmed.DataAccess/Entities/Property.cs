using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class Property
{
    [Key]
    public int IdProperty { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }
    public string Country { get; set; }
    public string StarCategory { get; set; }
    public string ChainName { get; set; }
    public string GiataCode { get; set; }
}