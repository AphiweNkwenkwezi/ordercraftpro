using Microsoft.AspNetCore.SignalR;

namespace OrderCraftPro.SignalR
{
    public class CustomerHub : Hub
    {
        public async Task SendCustomerAddedNotification()
        {
            await Clients.All.SendAsync("CustomerAdded");
        }
    }
}
