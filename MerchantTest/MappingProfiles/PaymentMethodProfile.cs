using Autofac;
using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Domain.Entities;

namespace MerchantTest.Api.MappingProfiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<CreatePaymentMethodRequest, PaymentMethod>();
        }
    }
}
