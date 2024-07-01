using StayConfirmed.DataAccess.Enums;

namespace StayConfirmed.DataAccess.Entities;

public class ReservationCustomerStatus : BaseEntity
{

    public CustomerStatusState State { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
}