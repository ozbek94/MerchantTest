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

        //bu entity için idye göre get methodu yazılacak
        public async Task<PaymentRequest> GetPaymentRequestById(int Id)
        {
            var paymentMethod = await _dbContext.PaymentRequests.FirstOrDefaultAsync(x => x.Id == Id);

            return paymentMethod;
        }
        

        //bu entity için idye göre delete methodu yazılacak
        public async Task DeletePaymentRequestById(int Id)
        {
            var paymentMethod = await _dbContext.PaymentRequests.FirstOrDefaultAsync(x => x.Id == Id);

            _dbContext.PaymentRequests.Remove(paymentMethod);
            await _dbContext.SaveChangesAsync();
        }

        //bu entity için idye göre update methodu yazılacak
        public async Task UpdatePaymentRequestById(int Id, PaymentRequest paymentRequest)
        {
            var paymentMethod = await _dbContext.PaymentRequests.FirstOrDefaultAsync(x => x.Id == Id);

            paymentMethod = paymentRequest;
            await _dbContext.SaveChangesAsync();
        }

        //bu entity için insert methodu yazılacak
        public async Task InsertPaymentRequest(PaymentRequest paymentRequest)
        {
            await _dbContext.PaymentRequests.AddAsync(paymentRequest);
            await _dbContext.SaveChangesAsync();
        }
    }
}
