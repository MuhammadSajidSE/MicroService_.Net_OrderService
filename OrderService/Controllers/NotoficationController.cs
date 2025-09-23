using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using OrderService.Services;

namespace OrderService.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class NotoficationController : ControllerBase
    {
        private readonly NotificationClient _notificationclient;
        public NotoficationController(NotificationClient notificationclient)
        {
            _notificationclient = notificationclient;
        }
        [HttpPost("AddNotification")]
        public async Task<IActionResult> GenerateNotification(NotificationDTO notificationDTO)
        {
            try
            {
                var result = await _notificationclient.AddNotification(notificationDTO);
                return Ok(new
                {
                    Message = "Notification sent successfully",
                    Notification = notificationDTO,
                    ServiceResponse = result
                });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { Message = "Failed to send notification", Error = ex.Message });
            }
        }
    }
}