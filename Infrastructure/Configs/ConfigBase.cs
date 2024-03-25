using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace MerchantTest.Infrastructure.Configs
{
    public abstract class ConfigBase<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty("DeleteTime");

            if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime?))
            {
                builder.HasQueryFilter(e => EF.Property<DateTime?>(e, "DeleteTime") == null);
            }
        }
    }
}
