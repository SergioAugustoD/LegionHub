using System;
using AutoMapper;
using LegionHubApi.Application.DTOs;
using LegionHubApi.Domain.Entities;

namespace LegionHubApi.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
