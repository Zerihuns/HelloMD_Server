using AutoMapper;
using HelloMD.Dtos;
using HelloMD.models;
using HelloMD.Models;

namespace HelloMD.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap(); 
        }
    }
}
