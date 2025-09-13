using Microsoft.AspNetCore.Mvc;
using OrderService.Common_Repository;
using OrderService.DTO;
using OrderService.Models;
using OrderService.Return_Data;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CommonRepoInterfac<Order, OrderDTO> orderinterface;
        public OrderController(CommonRepoInterfac<Order, OrderDTO> _orderinterface)
        {
            orderinterface = _orderinterface;
        }
        [HttpPost]
        public async Task<CommonRetrun> InsertUser(OrderDTO userDTO)
        {
            var data = await orderinterface.AddOrder(userDTO);
            return data;
        }
        [HttpGet("AllUser")]
        public async Task<CommonRetrun> GetAllUser()
        {
            var data = await orderinterface.GetAllOrder();
            return data;
        }
    }
}
