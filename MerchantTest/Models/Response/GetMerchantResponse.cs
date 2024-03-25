using MerchantTest.Domain.Entities;

namespace MerchantTest.Api.Models.Response
{
    public class GetMerchantResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Url { get; set; }
        public List<GetPaymentMethodResponse> PaymentMethodResponses { get; set; }
    }
}
