namespace MerchantTest.Domain.Entities
{
    public class ConfigurationType : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
