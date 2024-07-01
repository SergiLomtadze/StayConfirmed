using StayConfirmed.DataAccess.Enums;

namespace StayConfirmed.DataAccess.Entities
{
    public class PropertyContact : BaseEntity
    {
        public PropertyContactType Type { get; set; }
        public string Value { get; set; }
        public PropertyContactSource Source { get; set; }
        public int Priority { get; set; }
        public int IdPropertyInfo { get; set; }
    }
}
