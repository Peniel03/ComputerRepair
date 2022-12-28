using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.Presentation.Profiles
{
    public class ReviewProfiles: Profile
    {
        public ReviewProfiles()
        {
            // Source --> Destination
            CreateMap<Review, ReviewReadDto>();
            CreateMap<ReviewCreateDto, Review>();
        }
    }
}
