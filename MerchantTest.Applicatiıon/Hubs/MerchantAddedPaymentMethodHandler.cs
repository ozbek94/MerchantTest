using MediatR;
using MerchantTest.Domain.Events;
using Microsoft.AspNetCore.SignalR;

namespace MerchantTest.Applicatiıon.Hubs
{
    public class MerchantAddedPaymentMethodHandler : INotificationHandler<MerchandAddPaymentMethodEvent>
    {
        private readonly IHubContext<MerchantHub> _hubContext;

        public MerchantAddedPaymentMethodHandler(IHubContext<MerchantHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(MerchandAddPaymentMethodEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"asdasdas");
            return _hubContext.Clients.All.SendAsync("ReceiveMessage", notification.NewMerchantAfterAdded.MerchantPaymentMethods.Select(x => x.PaymentMethod)
                .Distinct()
                .ToList() 
                + " was updated", cancellationToken);
        }
    }
}
