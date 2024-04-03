using MerchantTest.Domain.Enums;

namespace MerchantTest.Api.Models.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Url { get; set; }
        public List<int> PaymentRequestIds { get; set; }
        public string Adress { get; set; }
        public ConfigurationEnum Configuration { get; set; }
    }
}
