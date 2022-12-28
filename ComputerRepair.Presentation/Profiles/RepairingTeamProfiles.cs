using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.Presentation.Profiles
{
    public class RepairingTeamProfiles:Profile
    {
        public RepairingTeamProfiles()
        {
            // Source --> Destination
            CreateMap<RepairingTeam, RepairingTeamReadDto>();
            CreateMap<RepairingTeamCreateDto, RepairingTeam>();
        }
    }
}
