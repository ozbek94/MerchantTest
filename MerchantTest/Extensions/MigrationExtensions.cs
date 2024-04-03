using MerchantTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MerchantTest.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using PostgreSqlContext dbContext =
                scope.ServiceProvider.GetRequiredService<PostgreSqlContext>();

            dbContext.Database.Migrate();
        }
    }
}
