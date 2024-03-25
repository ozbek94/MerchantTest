using MerchantTest.Domain.Entities;

namespace MerchantTest.Applicatiıon.Repositories
{
    public interface IMerchantRepository : IRepository<Merchant>
    {
        Task<Merchant> AssignPaymentMethodsToMerchantAsync(int merchantId, List<int> paymentMethodIds);   
        Task<Merchant> GetMerchantDetailsByIdAsync(int merchantId);
    }
}
