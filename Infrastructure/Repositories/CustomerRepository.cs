using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MerchantTest.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(PostgreSqlContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> AssignPaymentRequestsToCustomerAsync(int customerId, List<int> paymentRequestIds)
        {
            var customerPaymentRequests = new List<CustomerPaymentRequest>();
            var tables = await FindMerchanPaymentRequestWithCustomerIdAndPaymentRequestId(customerId, paymentRequestIds);

            foreach (var id in paymentRequestIds)
            {
                if (!tables.Any(x => x.PaymentRequestId == id))
                {
                    var customerPaymentRequest = new CustomerPaymentRequest
                    {
                        CustomerId = customerId,
                        PaymentRequestId = id
                    };
                    customerPaymentRequests.Add(customerPaymentRequest);
                }
            }

            await _dbContext.CustomerPaymentRequests.AddRangeAsync(customerPaymentRequests);
            var customer = await _dbContext.Customers.Where(x => x.Id == customerId).FirstOrDefaultAsync();

            await _dbContext.SaveChangesAsync();

            return (customer);
        }

        public async Task<Customer> GetCustomerDetailsByIdAsync(int customerId)
        {
            var customer = await _dbContext.Customers.Where(x => x.Id == customerId)
                .Include(x => x.CustomerPaymentRequests)
                .ThenInclude(x => x.PaymentRequest)
                .FirstOrDefaultAsync();
            return customer;
        }

        private async Task<List<CustomerPaymentRequest>> FindMerchanPaymentRequestWithCustomerIdAndPaymentRequestId(int customerId, List<int> paymentRequestIds)
        {
            var tables = await _dbContext.CustomerPaymentRequests.Where(x => paymentRequestIds.Contains(x.PaymentRequestId) && x.CustomerId == customerId).ToListAsync();

            return tables;
        }
    }
}
