using AutoMapper;
using Data_Access.Entities;
using WebAPI.Helpers.DTO;

namespace WebAPI.Helpers.Mappers
{
    public class APIMapProfile : Profile
    {
        public APIMapProfile()
        {
            CreateMap<ClaimsDTO, Claims>().ReverseMap();
            CreateMap<ClaimsEditDTO,Claims>().ReverseMap();
            CreateMap<ApprovedRequests, ApprovedDTO>().ReverseMap();
            CreateMap<DeclineRequests,DeclineDTO>().ReverseMap();
        }

    }
}
