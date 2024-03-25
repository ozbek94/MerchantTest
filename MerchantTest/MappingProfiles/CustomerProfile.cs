using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Api.Models.Response;
using MerchantTest.Domain.Entities;

namespace MerchantTest.Api.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<Customer, GetCustomerResponse>()
                .ForMember(dest => dest.PaymentRequestResponses, opt => opt.MapFrom(src => GetCustomerPaymentRequestResponse(src.CustomerPaymentRequests)));
        }

        private List<GetPaymentRequestResponse> GetCustomerPaymentRequestResponse(List<CustomerPaymentRequest> customerPaymentRequests)
        {
            var paymentRequestRepsonses = new List<GetPaymentRequestResponse>();
            foreach (var m in customerPaymentRequests)
            {
                var paymentRequestResponse = new GetPaymentRequestResponse();
                paymentRequestResponse.Name = m.PaymentRequest.Name;
                paymentRequestResponse.Id = m.PaymentRequest.Id;

                paymentRequestRepsonses.Add(paymentRequestResponse);
            }

            return paymentRequestRepsonses;
        }
    }
}
