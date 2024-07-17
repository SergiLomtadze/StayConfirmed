using StayConfirmed.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class Transaction
{
    [Key]
    public int IdTransaction { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public int IdStakeholder { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionReason Reason { get; set; }
    public decimal Amount { get; set; }
    public int IdReservation { get; set; }
    public int IdCurrency { get; set; }
}
