using MerchantTest.Domain.Entities;

namespace MerchantTest.Applicatiıon.Repositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod>
    {
        Task<List<PaymentMethod>> GetPaymentMethodsByIds(List<int> Ids);
    }
}
