using Microsoft.AspNet.SignalR;

namespace DNTCms.Web.Hubs
{
    public class NotificationHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}