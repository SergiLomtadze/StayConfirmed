namespace StayConfirmed.DataAccess.Entities;

public class Property : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }
    public string Country { get; set; }
    public string StarCategory { get; set; }
    public string ChainName { get; set; }
    public string GiataCode { get; set; }
}