using StayConfirmed.DataAccess.Enums;
using StayConfirmed.DataAccess.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities;

public class InputFromCustomer
{
    [Key]
    public int IdInputFromCustomer { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public int IdBrand { get; set; }
    public string CustomerReservationCode { get; set; }
    public string ProviderReservationCode { get; set; }
    public string ProviderReservationCodeLocal { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string RoomName { get; set; }
    public string MealPlane { get; set; }
    public ICollection<Pax> Paxes { get; set; } = [];
    public string PropertyName { get; set; }
    public string PropertyAddress { get; set; }
    public string PropertyCounty { get; set; }
    public string PropertyEmail { get; set; }
    public string CustomerCodeForProperty { get; set; }
    public string ProviderCodeForProperty { get; set; }
    public string GiataCodeForProperty { get; set; }
    public int IdProperty { get; set; }
    public int HoursBeforeCheck { get; set; }
    public int Priority { get; set; }
    public string ContactEmail { get; set; }
    public ActionType Action { get; set; }

    public void AddPax(Pax pax)
    {
        if (pax is null)
        {
            return;
        }

        Paxes.Add(pax);
    }

    public void RemovePax(Pax pax)
    {
        Paxes.Remove(pax);
    }

    public void RemovePaxes()
    {
        Paxes.Clear();
    }

}
