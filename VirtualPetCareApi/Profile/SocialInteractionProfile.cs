using AutoMapper;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Models;

public class SocialInteractionProfile : Profile
{
    public SocialInteractionProfile()
    {
        CreateMap<SocialInteractionDto, SocialInteraction>().ReverseMap();
    }
}
