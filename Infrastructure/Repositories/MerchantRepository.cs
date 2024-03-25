using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace MerchantTest.Infrastructure.Repositories
{
    public class MerchantRepository : RepositoryBase<Merchant>, IMerchantRepository
    {
        public MerchantRepository(PostgreSqlContext dbContext) : base(dbContext)
        {
        }

        public async Task<Merchant> AssignPaymentMethodsToMerchantAsync(int merchantId, List<int> paymentMethodIds)
        {
            var merchantPaymentMethods = new List<MerchantPaymentMethod>();
            var tables = await FindMerchanPaymentMethodWithMerchantIdAndPaymentMethodId(merchantId, paymentMethodIds);

            foreach (var id in paymentMethodIds)
            {
                if(!tables.Any(x => x.PaymentMethodId == id))
                {
                    var merchantPaymentMethod = new MerchantPaymentMethod
                    {
                        MerchantId = merchantId,
                        PaymentMethodId = id
                    };
                    merchantPaymentMethods.Add(merchantPaymentMethod);
                }
            }

            await _dbContext.MerchantPaymentMethods.AddRangeAsync(merchantPaymentMethods);
            var merchant = await _dbContext.Merchants.Where(x => x.Id == merchantId).FirstOrDefaultAsync();

            await _dbContext.SaveChangesAsync();

            return (merchant);
        }

        public async Task<Merchant> GetMerchantDetailsByIdAsync(int merchantId)
        {
            var merchant = await _dbContext.Merchants.Where(x => x.Id == merchantId)
                .Include(x => x.MerchantPaymentMethods)
                .ThenInclude(x => x.PaymentMethod)
                .FirstOrDefaultAsync();

            return merchant;
        }

        private async Task<List<MerchantPaymentMethod>> FindMerchanPaymentMethodWithMerchantIdAndPaymentMethodId(int merchantId, List<int> paymentMethodIds)
        {
            var tables = await _dbContext.MerchantPaymentMethods.Where(x => paymentMethodIds.Contains(x.PaymentMethodId) && x.MerchantId == merchantId).ToListAsync();

            return tables;
        }
    }
}
