using AutoMapper;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Models;

public class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        CreateMap<ActivityDto, Activity>().ReverseMap();
    }
}
