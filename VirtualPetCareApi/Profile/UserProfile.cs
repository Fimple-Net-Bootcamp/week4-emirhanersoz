using AutoMapper;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Models;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<UserDto, User>().ReverseMap();
    }
}
