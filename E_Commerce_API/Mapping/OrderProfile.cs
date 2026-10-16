using AutoMapper;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;

namespace E_Commerce_API.Mapping
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponeDTO>();
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrderUpdateDTO, Order>();

            CreateMap<OrderUpdateStatusDTO, Order>().
                ForAllMembers(w => w.Condition((x, y, z) => z != null));
        }
    }
}
