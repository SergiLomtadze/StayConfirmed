namespace StayConfirmed.DataAccess.Entities
{
    public class MapProvider : BaseEntity
    {
        public int IdStakeholderCustomer { get; set; }
        public int IdStakeholderProvider { get; set; }
        public string CustomerProvidedCode { get; set; }
    }
}
