using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantTest.Domain
{
    public class BaseEntity<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TId Id { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? DeleteTime { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
            

        public BaseEntity()
        {
            InsertTime = DateTime.UtcNow;
        }
    }
}
