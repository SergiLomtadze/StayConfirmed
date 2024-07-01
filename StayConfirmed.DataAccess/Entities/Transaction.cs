using StayConfirmed.DataAccess.Enums;

namespace StayConfirmed.DataAccess.Entities;

public class Transaction : BaseEntity
{
    public int IdStakeholder { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionReason Reason { get; set; }
    public decimal Amount { get; set; }
    public int IdReservation { get; set; }
    public int IdCurrency { get; set; }
}
