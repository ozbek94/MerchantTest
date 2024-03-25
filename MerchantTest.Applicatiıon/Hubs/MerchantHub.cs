using Microsoft.AspNetCore.SignalR;

namespace MerchantTest.Applicatiıon.Hubs
{
    public class MerchantHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"asdfasdfasf");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"asdfafdas");
            return base.OnDisconnectedAsync(exception);
        }
        public Task UpdateMerchantAsync(string message)
        {
            // TODO: Avoid having messages appear to the user initiating them
            return Clients.Others.SendAsync("ReceiveMessage", message);
        }
    }
}
