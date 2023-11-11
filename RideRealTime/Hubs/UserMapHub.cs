using Microsoft.AspNetCore.SignalR;
using DTOs.RideRealtime;
using Abstraction.RideRealTime;

namespace RideRealTime.Hubs
{
    public class UserMapHub : Hub<IUserMapHub>
    {
        public Task SendRiderLocation(MapLocationDTO location)
        {
            return Clients.All.Testing(location);
        }
    }
}
