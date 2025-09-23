using Microsoft.AspNetCore.Mvc;
using OrderService.Common_Repository;
using OrderService.DTO;
using OrderService.Models;
using OrderService.Return_Data;
using OrderService.Services;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserClient _userClient;
        private readonly CommonRepoInterfac<Order, OrderDTO> orderinterface;
        public OrderController(CommonRepoInterfac<Order, OrderDTO> _orderinterface, UserClient userClient)
        {
            orderinterface = _orderinterface;
            _userClient = userClient;
        }
        [HttpPost("InsertOrder")]
        public async Task<CommonRetrun> InsertUser(OrderDTO userDTO)
        {
            var data = await orderinterface.AddOrder(userDTO);
            return data;
        }
        [HttpGet("AllOrder")]
        public async Task<CommonRetrun> GetAllUser()
        {
            var data = await orderinterface.GetAllOrder();
            return data;
        }
        [HttpGet("UsersFromGateway")]
        public async Task<IActionResult> GetUsersViaGateway()
        {
            var users = await _userClient.GetAllUsersFromGateway();
            return Ok(users);
        }
    }
}
