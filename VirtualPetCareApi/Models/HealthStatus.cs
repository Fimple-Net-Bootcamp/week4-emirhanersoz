using VirtualPetCareApi.Entity;

namespace VirtualPetCareApi.Models
{
    public class HealthStatus : Entity<int>
    {
        public int Health { get; set; }
        public int HappinessLevel { get; set; }
        public int HungerLevel { get; set; }
        public int CleanlinessLevel { get; set; }
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
