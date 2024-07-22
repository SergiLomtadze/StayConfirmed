using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class Wallet
{
    [Key]
    public int IdWallet { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public int IdStakeholder { get; set; }
    public decimal CurrentBalance { get; set; }
    public int IdCurrency { get; set; }
}
