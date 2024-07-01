namespace StayConfirmed.DataAccess.Entities
{
    public class PricingModel : BaseEntity
    {
        public decimal Price { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
