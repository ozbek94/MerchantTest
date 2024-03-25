using MerchantTest.Domain.Events;
using System.ComponentModel.DataAnnotations;

namespace MerchantTest.Domain.Entities
{
    public class Merchant : BaseEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool Status { get; set; }
        [Required]
        [MaxLength(100)]
        public string Url { get; set; }
        public virtual List<MerchantPaymentMethod> MerchantPaymentMethods { get; set; } // Merchant'ın ödeme yöntemleri listesi

        public void AddPaymentMethodsRange(List<PaymentMethod> paymentMethods)
        {
            if (this.MerchantPaymentMethods == null)
            {
                MerchantPaymentMethods = new List<MerchantPaymentMethod>();
            }
            // Ödeme yöntemlerini koleksiyona ekle
            foreach (var paymentMethod in paymentMethods)
            {
                var merchantPaymentMethod = new MerchantPaymentMethod
                {
                    MerchantId = this.Id,
                    PaymentMethodId = paymentMethod.Id
                };
                MerchantPaymentMethods.Add(merchantPaymentMethod);
            }

        }

        public void UpdateMercantPaymentMethodEvent()
        {
            var merchantAddedPaymentMethodEvent = new MerchandAddPaymentMethodEvent(this);
            Events.Add(merchantAddedPaymentMethodEvent);
        }
    }
}
