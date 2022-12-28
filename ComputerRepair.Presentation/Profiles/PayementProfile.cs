using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.Presentation.Profiles
{
    public class PayementProfiles:Profile
    {
        public PayementProfiles()
        {
            // Source --> Destination
            CreateMap<Payement, PayementReadDto>();
            CreateMap<PayementCreateDto, Payement>();

        }
      }
}
