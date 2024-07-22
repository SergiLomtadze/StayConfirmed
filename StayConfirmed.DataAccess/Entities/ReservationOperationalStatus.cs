using StayConfirmed.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class ReservationOperationalStatus
{
    [Key]
    public int IdReservationOperationalStatus { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public OprationalStatusState State { get; set; }
}
