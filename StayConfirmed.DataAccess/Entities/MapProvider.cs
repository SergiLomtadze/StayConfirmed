using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities
{
    public class MapProvider
    {
        [Key]
        public int IdMapProvider { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; }
        public int IdStakeholderCustomer { get; set; }
        public int IdStakeholderProvider { get; set; }
        public string CustomerProvidedCode { get; set; }
    }
}
