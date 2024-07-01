namespace StayConfirmed.DataAccess.ValueObjects;

public sealed class Pax
{
    public string Name  { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public DateTime Birtdate { get; set; }
    public int Age { get; set; }
}
