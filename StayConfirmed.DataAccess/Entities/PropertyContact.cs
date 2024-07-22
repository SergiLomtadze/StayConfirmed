using StayConfirmed.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace StayConfirmed.DataAccess.Entities
{
    public class PropertyContact
    {
        [Key]
        public int IdPropertyContact { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; }
        public PropertyContactType Type { get; set; }
        public string Value { get; set; }
        public PropertyContactSource Source { get; set; }
        public int Priority { get; set; }
        public int IdPropertyInfo { get; set; }
    }
}
