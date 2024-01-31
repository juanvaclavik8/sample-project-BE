using Microsoft.AspNetCore.Mvc;
using SensxWebApi.Helper;
using SensxWebApi.Services;

namespace SensxWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensxController : ControllerBase
    {
        private INotificationService notificationService;

        public SensxController(INotificationService ns)
        {
            notificationService = ns;
        }

        [HttpGet(Name = "Ping")]
        public IActionResult Get()
        {
            try
            {
                notificationService.SendNotifications();

                return Ok(new { Message = "Pong" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(Name = "PostData")]
        public IActionResult Post([FromQuery] string data)
        {
            try
            {
                // Print user input to the console
                Console.WriteLine(data);

                if (!String.IsNullOrEmpty(data))
                {
                    // Reverse user input chars via custom helper method
                    var reversed = data.Reverse();

                    // Pass reversed input to the service
                    notificationService.Message = reversed;
                }

                return Ok(new { Message = "Data received" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
