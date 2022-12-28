using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.Presentation.Profiles
{
    public class UserProfiles:Profile
    {

        public UserProfiles()
        {
            // Source --> Destination

            CreateMap<User, UserReadDto>();


            //.ForMember(dest => dest.Farm, source => source.Ignore())
            //.ReverseMap();
            CreateMap<UserCreateDto, User>();
        }
    }
}
