namespace StayConfirmed.DataAccess.Entities;

public class Wallet : BaseEntity
{
    public int IdStakeholder { get; set; }
    public decimal CurrentBalance { get; set; }
    public int IdCurrency { get; set; }
}
