using AutoMapper;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Models;

public class TrainingProfile : Profile
{
    public TrainingProfile()
    {
        CreateMap<TrainingDto, Training>().ReverseMap();
    }
}
