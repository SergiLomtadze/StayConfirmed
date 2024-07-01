namespace StayConfirmed.DataAccess.Entities;

public class ReservationComunication : BaseEntity
{
    public int IdUser { get; set; }
    public int IdReservation { get; set; }
    public DateTime? DateSendEmail { get; set; }
    public DateTime? DateReceiveEmail { get; set; }
    public DateTime? DatePhoneCall { get; set; }
    public string Note  { get; set; }
}
