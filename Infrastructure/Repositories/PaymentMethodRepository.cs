using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MerchantTest.Infrastructure.Repositories
{
    public class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(PostgreSqlContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<PaymentMethod>> GetPaymentMethodsByIds(List<int> Ids)
        {
            var paymentMethods = await _dbContext.PaymentMethods.Where(x => Ids.Contains(x.Id)).ToListAsync();

            return paymentMethods;
        }
    }
}
