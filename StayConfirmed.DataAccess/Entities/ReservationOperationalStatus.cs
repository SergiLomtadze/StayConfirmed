using StayConfirmed.DataAccess.Enums;

namespace StayConfirmed.DataAccess.Entities;

public class ReservationOperationalStatus : BaseEntity
{
    public OprationalStatusState State { get; set; }
}
