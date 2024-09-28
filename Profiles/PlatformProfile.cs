using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles;

public class PlatformProfile : Profile
{
    public PlatformProfile()
    {
        /* 
            Source -> Target
            Platfrom(Model) is the source and PlatfroReadDto(Dto) is target
        */
        CreateMap<Platform,PlatformReadDto>();

        /* 
            Source -> Target
            PlatfroCreateDto(Dto) is the source and Platfrom(Model) is target
        */
        CreateMap<PlatformCreateDto,Platform>();



    }
}