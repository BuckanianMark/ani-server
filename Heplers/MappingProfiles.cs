using ani_server.Dto;
using ani_server.Models;
using AutoMapper;

namespace ani_server.Heplers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {           
        CreateMap<AnimeRequestDto,Anime>();
        CreateMap<RegisterRequestDto,UserMaster>();

        }
    }
}