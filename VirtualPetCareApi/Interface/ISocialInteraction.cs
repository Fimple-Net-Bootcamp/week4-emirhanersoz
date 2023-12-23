using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface ISocialInteraction
    {
        List<SocialInteraction> GetAll();
        SocialInteraction GetById(int Id);
        void Insert(SocialInteraction SocialInteraction);
    }
}
