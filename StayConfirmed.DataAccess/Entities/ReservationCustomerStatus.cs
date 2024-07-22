using StayConfirmed.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class ReservationCustomerStatus
{
    [Key]
    public int IdReservationCustomerStatus { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public CustomerStatusState State { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
}