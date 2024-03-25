using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection;

namespace MerchantTest.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly PostgreSqlContext _dbContext;

        protected RepositoryBase(PostgreSqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().AddRange(entities);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entities;
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<T?> FindAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public virtual async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }


        public virtual async Task SoftDeleteAsync<TId>(TId Id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<T>().FindAsync(new object[] { Id }, cancellationToken: cancellationToken);

            PropertyInfo propertyInfo = entity.GetType().GetProperty("DeleteTime");

            if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime?))
            {
                propertyInfo.SetValue(entity, DateTime.UtcNow, null);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new ArgumentException("The entity must have a nullable DateTime property named DeleteTime.");
            }
        }

        public virtual async Task<T> GetSpecAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }

}