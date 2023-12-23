using AutoMapper;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Models;

public class FoodProfile : Profile
{
    public FoodProfile()
    {
        CreateMap<FoodDto, Food>().ReverseMap();
    }
}
