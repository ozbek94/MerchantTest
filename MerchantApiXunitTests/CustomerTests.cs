using AutoMapper;
using MerchantTest.Api.Controllers.Customers;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Applicatiýon.Repositories;
using MerchantTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MerchantApiXunitTests
{
    public class CustomerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IPaymentRequestRepository> _paymentRequestRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<CustomerController>> _loggerMock;

        public CustomerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _paymentRequestRepositoryMock = new Mock<IPaymentRequestRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<CustomerController>>();
        }


        [Fact]
        public void AddPaymentRequest_Adds_PaymentRequest_To_CustomerPaymentRequests()
        {
            // Arrange
            var customer = new Customer();
            var paymentRequest = new PaymentRequest { Id = 1, Name = "nedime", DeleteTime = null, InsertTime = DateTime.UtcNow };

            // Act
            if (paymentRequest != null)
            {
                customer.AddPaymentRequest(paymentRequest);
            }

            // Assert
            Assert.NotNull(paymentRequest); // Müþteri ödeme isteklerinin null olmadýðýný kontrol et
            Assert.Equal(paymentRequest.Id, customer.CustomerPaymentRequests.First().PaymentRequestId);
        }

        [Fact]
        public void AddPaymentRequestsRange_Adds_PaymentRequests_To_CustomerPaymentRequests()
        {
            // Arrange
            var customer = new Customer();
            var paymentRequests = new List<PaymentRequest>
        {
            new PaymentRequest { Id = 1 },
            new PaymentRequest { Id = 2 },
            new PaymentRequest { Id = 3 }
        };

            // Act
            customer.AddPaymentRequestsRange(paymentRequests);

            // Assert
            Assert.NotNull(customer.CustomerPaymentRequests);
            Assert.Equal(paymentRequests.Count, customer.CustomerPaymentRequests.Count);
        }
    }


}

