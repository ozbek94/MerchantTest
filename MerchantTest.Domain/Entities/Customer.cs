using MerchantTest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MerchantTest.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool Status { get; set; }
        [Required]
        [MaxLength(100)]
        public string Url { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        public ConfigurationEnum Configuration { get; set; }



        public virtual List<CustomerPaymentRequest> CustomerPaymentRequests { get; set; }

        public void AddPaymentRequestsRange(List<PaymentRequest> paymentRequests)
        {
            if (this.CustomerPaymentRequests == null)
            {
                CustomerPaymentRequests = new List<CustomerPaymentRequest>();
            }

            foreach (var paymentRequest in paymentRequests)
            {
                AddPaymentRequest(paymentRequest);
            }
        }

        public void AddPaymentRequest(PaymentRequest paymentRequest)
        {
            if (paymentRequest != null)
            {
                var customerPaymentRequest = new CustomerPaymentRequest
                {
                    CustomerId = this.Id,
                    PaymentRequestId = paymentRequest.Id
                };

                if (CustomerPaymentRequests == null)
                {
                    CustomerPaymentRequests = new List<CustomerPaymentRequest>();
                }

                if (customerPaymentRequest != null)
                {
                    CustomerPaymentRequests.Add(customerPaymentRequest); 
                }
            }

        }
    }
}
