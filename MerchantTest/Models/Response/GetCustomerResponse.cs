using MerchantTest.Domain.Enums;

namespace MerchantTest.Api.Models.Response
{
    public class GetCustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Url { get; set; }
        public List<GetPaymentRequestResponse> PaymentRequestResponses { get; set; }
        public ConfigurationEnum Configuration { get; set; }
    }
}
