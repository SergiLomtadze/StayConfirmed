using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class ReservationComunication
{
    [Key]
    public int IdReservationComunication { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public int IdUser { get; set; }
    public int IdReservation { get; set; }
    public DateTime? DateSendEmail { get; set; }
    public DateTime? DateReceiveEmail { get; set; }
    public DateTime? DatePhoneCall { get; set; }
    public string Note  { get; set; }
}
