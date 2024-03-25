using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MerchantApiXunitTests
{
    public class RepositoryTests
    {
        private Mock<DbContext> _dbContextMock;
        private Mock<DbSet<Customer>> _dbSetMock;
        private IRepository<Customer> _repository;

        public RepositoryTests(IRepository<Customer> repository)
        {
            _dbContextMock = new Mock<DbContext>();
            _dbSetMock = new Mock<DbSet<Customer>>();
            _repository = repository;
        }

        //[Fact]
        //public async Task AddAsync_WhenEntityIsValid_ShouldAddEntityToDatabase()
        //{
        //    // Arrange
        //    var entity = new Customer(); // Create a new instance of the entity
        //    _dbContextMock.Setup(db => db.Set<Customer>()).Returns(_dbSetMock.Object); // Setup DbContext to return DbSet mocktask with the entity
        //    _dbContextMock.Setup(db => db.SaveChangesAsync(default)).ReturnsAsync(1); // Setup SaveChangesAsync to return 1 indicating success

        //    // Act
        //    var result = await _repository.AddAsync(entity);

        //    // Assert
        //    Assert.NotNull(result); // Ensure result is not null
        //    Assert.Equal(entity, result); // Ensure returned entity is the same as the one passed to AddAsync
        //    _dbSetMock.Verify(ds => ds.AddAsync(entity, default), Times.Once); // Verify AddAsync is called once with the entity
        //    _dbContextMock.Verify(db => db.SaveChangesAsync(default), Times.Once); // Verify SaveChangesAsync is called once
        //}
    }
}
