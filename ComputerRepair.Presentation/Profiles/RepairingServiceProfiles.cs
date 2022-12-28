using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.Presentation.Profiles
{
    public class RepairingServiceProfiles:Profile
    {
        public RepairingServiceProfiles()
        {
            // Source --> Destination
            CreateMap<RepairingService, RepairingServiceReadDto>();
            CreateMap<RepairingServiceCreateDto, RepairingService>();
        }
    }
}
