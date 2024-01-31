using Microsoft.AspNetCore.Mvc;

namespace SensxWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public string Get()
        {
            try
            {
                return "Notification successfully sent";
            }
            catch (Exception)
            {

                throw;
            }   
        }
    }
}
