using Microsoft.AspNetCore.SignalR;
using WebChungKhoan3._0.Repositories;
namespace WebChungKhoan3._0.Hubs
{
    public class DashBoardHub:Hub
    {
        Item Item;
        public DashBoardHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ChungKhoan");
            Item = new Item(connectionString);
        }
        public async Task SendOrder()
        {
            
            var Orders = Item.GetOrder();
            await Clients.All.SendAsync("ReceiveOrder", Orders);
        } 
    }
}
