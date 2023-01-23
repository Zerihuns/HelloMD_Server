using AutoMapper;
using HelloMD.Dtos;
using HelloMD.models;

namespace HelloMD.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
