using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities
{
    public class PricingModel
    {
        [Key]
        public int IdPricingModel { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
