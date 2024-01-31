using Microsoft.AspNetCore.SignalR;
using SensxWebApi.Hub;

namespace SensxWebApi.Services
{
    public class NotificationService : INotificationService
    {
        public int totalMessageCharsCount;
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(3);
        private readonly IHubContext<MessageHub, IMessageHubClient> messageHub;
       
        
        private int notificationsCount;



        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public NotificationService(IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            messageHub = _messageHub;
            notificationsCount = 1;
            totalMessageCharsCount = 0;
            message = string.Empty;

            Console.WriteLine("Notification service created");
        }

        public async Task SendNotifications()
        {
            while (notificationsCount <= 10 && totalMessageCharsCount <= 40)
            {
                var time = DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss");

                // Put together notification
                var notification = $"{time} ";

                // add message if present
                if(!string.IsNullOrEmpty(message))
                {
                    notification += message;
                    totalMessageCharsCount += message.Length;
                    message = string.Empty;
                }

                // Send a message every 3 seconds
                await messageHub.Clients.All.SendNotificationToUser(notification);
                await Task.Delay(_interval);

                // Log important info
                Console.WriteLine($"notificationsCount: {notificationsCount}");
                Console.WriteLine($"message: {message}");
                Console.WriteLine($"message.Length: {message.Length}");

                notificationsCount++;

                Console.WriteLine($"totalMessageCharsCount: {totalMessageCharsCount}");
            }

            // Set notification service to default after one application cycle           
            notificationsCount = 1;
            totalMessageCharsCount = 0;

            // Notify FE that application cycle is finished
            await messageHub.Clients.All.SendNotificationToUser("finished");
        }
    }
}
