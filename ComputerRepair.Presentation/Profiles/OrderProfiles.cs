using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.Presentation.Profiles
{
    public class OrderProfiles: Profile
    {
        public OrderProfiles()
        {
            // Source --> Destination

            CreateMap<Order, OrderReadDto>();

            CreateMap<OrderCreateDto, Order>();
        }
    }
}
