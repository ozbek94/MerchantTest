namespace MerchantTest.Domain.Entities
{
    public class PaymentRequest : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual List<CustomerPaymentRequest> CustomerPaymentRequests { get; set; }
    }
}
