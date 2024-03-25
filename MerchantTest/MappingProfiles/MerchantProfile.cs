using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Api.Models.Response;
using MerchantTest.Domain.Entities;

namespace MerchantTest.Api.MappingProfiles
{
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            CreateMap<CreateMerchantRequest, Merchant>();
            CreateMap<Merchant, GetMerchantResponse>()
                .ForMember(dest => dest.PaymentMethodResponses, opt => opt.MapFrom(src => GetMerchantPaymentMethodResponse(src.MerchantPaymentMethods)));
        }

        private List<GetPaymentMethodResponse> GetMerchantPaymentMethodResponse(List<MerchantPaymentMethod> merchantPaymentMethods)
        {
            var paymentMethodRepsonses = new List<GetPaymentMethodResponse>();
            foreach (var m in merchantPaymentMethods)
            {
                var paymentMethodResponse = new GetPaymentMethodResponse();
                paymentMethodResponse.Name = m.PaymentMethod.Name;
                paymentMethodResponse.Id = m.PaymentMethod.Id;

                paymentMethodRepsonses.Add(paymentMethodResponse);
            }

            return paymentMethodRepsonses;
        }
    }
}
