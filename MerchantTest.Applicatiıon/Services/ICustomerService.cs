using MerchantTest.Applicatiıon.DTOs;

namespace MerchantTest.Applicatiıon.Services
{
    public interface ICustomerService
    {
        Task<OperationResult> AssignPaymentRequestToCustomer(int MerhcantId, List<int> PaymentRequestIds);
    }
}
