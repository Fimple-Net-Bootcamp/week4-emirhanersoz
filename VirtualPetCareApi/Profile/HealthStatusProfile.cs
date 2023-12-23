using AutoMapper;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Models;

public class HealthStatusProfile : Profile
{
    public HealthStatusProfile()
    {
        CreateMap<HealthStatusDto, HealthStatus>().ReverseMap();
    }
}
