using System.ComponentModel.DataAnnotations;

namespace MerchantTest.Domain.Entities
{
    public class PaymentMethod : BaseEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual List<Merchant> Merchants { get; set; }
    }
}
