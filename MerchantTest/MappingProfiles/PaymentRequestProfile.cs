using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Domain.Entities;

namespace MerchantTest.Api.MappingProfiles
{
    public class PaymentRequestProfile : Profile
    {
        public PaymentRequestProfile()
        {
            CreateMap<CreatePaymentRequestRequest, PaymentRequest>();
        }
    }
}
