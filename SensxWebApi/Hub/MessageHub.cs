using Microsoft.AspNetCore.SignalR;

namespace SensxWebApi.Hub
{
    public class MessageHub : Hub<IMessageHubClient>
    {
    }
}
