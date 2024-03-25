using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MerchantTest.Infrastructure.Repositories
{
    public class PaymentRequestRepository : RepositoryBase<PaymentRequest>, IPaymentRequestRepository
    {
        public PaymentRequestRepository(PostgreSqlContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<PaymentRequest>> GetPaymentRequestsByIds(List<int> Ids)
        {
            var paymentMethods = await _dbContext.PaymentRequests.Where(x => Ids.Contains(x.Id)).ToListAsync();

            return paymentMethods;
        }
    }
}
