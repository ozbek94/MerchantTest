using MerchantTest.Domain.Entities;

namespace MerchantTest.Applicatiıon.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> AssignPaymentRequestsToCustomerAsync(int merchantId, List<int> paymentRequestIds);
        Task<Customer> GetCustomerDetailsByIdAsync(int merchantId);
    }
}
