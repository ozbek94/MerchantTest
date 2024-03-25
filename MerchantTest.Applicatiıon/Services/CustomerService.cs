using MerchantTest.Applicatiıon.DTOs;
using MerchantTest.Applicatiıon.Repositories;

namespace MerchantTest.Applicatiıon.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<OperationResult> AssignPaymentRequestToCustomer(int MerhcantId, List<int> PaymentRequestIds)
        {
            try
            {
                await _customerRepository.AssignPaymentRequestsToCustomerAsync(MerhcantId, PaymentRequestIds);
                return new OperationResult(true, "İşlem Başarılı");
            }
            catch (Exception message)
            {
                var validMessage = message.Message;
                return new OperationResult(false, validMessage);
            }
        }
    }
}
