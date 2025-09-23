using Microsoft.AspNetCore.Mvc;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class UserController : ControllerBase
    {
        private readonly UserClient _userClient;

        public UserController(UserClient userClient)
        {
            _userClient = userClient;
        }
        [HttpGet("CheckUsers")]
        public async Task<IActionResult> CheckUsers()
        {
            var users = await _userClient.GetAllUsersFromGateway();
            return Ok(users);
        }

    }
}
