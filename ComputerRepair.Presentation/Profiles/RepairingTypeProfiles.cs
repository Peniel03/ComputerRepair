using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.Presentation.Profiles
{
    public class RepairingTypeProfiles:Profile
    {
        public RepairingTypeProfiles()
        {
            // Source --> Destination
            CreateMap<RepairingType, RepairingTypeReadDto>();
            CreateMap<RepairingTypeCreateDto, RepairingType>();
        }
    }
}
