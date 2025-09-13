using AutoMapper;
using OrderService.DTO;
using OrderService.Models;
namespace OrderService.DataBase_Context
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
