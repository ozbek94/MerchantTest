using MerchantTest.Domain.Entities;

namespace MerchantTest.Applicatiıon.Repositories
{
    public interface IPaymentRequestRepository : IRepository<PaymentRequest>
    {
        Task<List<PaymentRequest>> GetPaymentRequestsByIds(List<int> Ids);
    }
}
