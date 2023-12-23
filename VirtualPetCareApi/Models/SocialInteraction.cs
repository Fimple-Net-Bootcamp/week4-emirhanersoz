using VirtualPetCareApi.Entity;

namespace VirtualPetCareApi.Models
{
    public class SocialInteraction : Entity<int>
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
    }
}
