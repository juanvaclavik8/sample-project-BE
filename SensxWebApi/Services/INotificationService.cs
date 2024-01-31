namespace SensxWebApi.Services
{
    public interface INotificationService
    {
        string Message { get; set; }

        Task SendNotifications();
    }
}
