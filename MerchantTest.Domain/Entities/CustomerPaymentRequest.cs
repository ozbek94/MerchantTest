namespace MerchantTest.Domain.Entities
{
    public class CustomerPaymentRequest : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PaymentRequestId { get; set; }
        public PaymentRequest PaymentRequest { get; set; }
    }
}
