using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;

namespace MerchantTest.Infrastructure.Contexts
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
           : base(options)
        {

        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<MerchantPaymentMethod> MerchantPaymentMethods { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentRequest> PaymentRequests { get; set; }
        public DbSet<CustomerPaymentRequest> CustomerPaymentRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new PaymentRequestConfig());
        }
    }
}
