using MerchantTest.Domain.Entities;

namespace MerchantTest.Domain.Events
{
    public class MerchandAddPaymentMethodEvent : BaseDomainEvent
    {
        private MerchantPaymentMethod merchantPaymentMethod;

        public MerchandAddPaymentMethodEvent(Merchant Merchant)
        {
            NewMerchantAfterAdded = Merchant;
        }

        public MerchandAddPaymentMethodEvent(MerchantPaymentMethod merchantPaymentMethod)
        {
            this.merchantPaymentMethod = merchantPaymentMethod;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Merchant NewMerchantAfterAdded { get; private set; }

    }
}
