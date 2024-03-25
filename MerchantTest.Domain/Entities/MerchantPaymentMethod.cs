using MerchantTest.Domain.Events;

namespace MerchantTest.Domain.Entities
{
    public class MerchantPaymentMethod : BaseEntity<int>
    {
        public int MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        public void UpdateMercantPaymentMethodEvent()
        {
            var merchantAddedPaymentMethodEvent = new MerchandAddPaymentMethodEvent(this);
            Events.Add(merchantAddedPaymentMethodEvent);
        }
    }
}
