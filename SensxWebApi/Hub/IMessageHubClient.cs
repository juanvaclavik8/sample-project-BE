namespace SensxWebApi.Hub
{
    public interface IMessageHubClient
    {
        Task SendNotificationToUser(string message);
    }
}
